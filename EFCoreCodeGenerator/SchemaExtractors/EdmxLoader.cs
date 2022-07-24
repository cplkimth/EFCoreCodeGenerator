#region
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public class EdmxLoader
{
    #region Properties
    /// <summary>
    /// </summary>
    public EdmItemCollection AllItems { get; private set; }

    /// <summary>
    /// </summary>
    public List<CompilerError> EdmxSchemaErrors { get; }

    /// <summary>
    /// </summary>
    public List<EntityType> Entities { get; private set; }


    /// <summary>
    /// </summary>
    public EntityContainer EntityContainer { get; private set; }

    /// <summary>
    /// </summary>
    public List<EntitySet> EntitySets => EntityContainer.BaseEntitySets.OfType<EntitySet>().ToList();

    /// <summary>
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// </summary>
    public string ModelNamespace { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// </summary>
    /// <param name="filePath"></param>
    public EdmxLoader(string filePath)
    {
        filePath = Path.GetFullPath(filePath);
        if (!File.Exists(Path.GetFullPath(filePath))) throw new ArgumentException("The filePath specified does not exist.");

        if (Path.GetExtension(filePath) != ".edmx") throw new ArgumentException("The filePath specified does point to an EDMX file.");

        EdmxSchemaErrors = new List<CompilerError>();
        FilePath = filePath;
        AllItems = new EdmItemCollection();
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// </summary>
    public void Load()
    {
        var root = XElement.Load(FilePath, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
        var schemaElement = root.Elements()
                                .Where(e => e.Name.LocalName == "Runtime")
                                .Elements()
                                .Where(e => e.Name.LocalName == "ConceptualModels")
                                .Elements()
                                .Where(e => e.Name.LocalName == "Schema")
                                .FirstOrDefault()
                            ?? root;

        if (schemaElement == null) throw new FileLoadException("The EDMX file could not be loaded.");

        var namespaceAttribute = schemaElement.Attribute("Namespace");
        ModelNamespace = namespaceAttribute != null ? namespaceAttribute.Value : "";

        using var reader = schemaElement.CreateReader();
        var itemCollection = EdmItemCollection.Create(new[] {reader}, null, out var errors);

        ProcessErrors(errors);

        if (itemCollection != null)
        {
            AllItems = itemCollection;

            Entities = itemCollection
                .OfType<EntityType>()
                .OrderBy(c => c.Name)
                .ToList();

            EntityContainer = itemCollection.OfType<EntityContainer>().FirstOrDefault();
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// </summary>
    /// <param name="errors"></param>
    private void ProcessErrors(IEnumerable<EdmSchemaError> errors)
    {
        foreach (var error in errors)
            EdmxSchemaErrors.Add(
                new CompilerError(
                    error.SchemaLocation ?? FilePath,
                    error.Line,
                    error.Column,
                    error.ErrorCode.ToString(CultureInfo.InvariantCulture),
                    error.Message)
                {
                    IsWarning = error.Severity == EdmSchemaErrorSeverity.Warning
                });
    }
    #endregion
}