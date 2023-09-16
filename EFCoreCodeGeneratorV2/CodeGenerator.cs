using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text.Json;
using System.Text;
using EFCoreCodeGeneratorV2.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGeneratorV2.Generators;

namespace EFCoreCodeGeneratorV2;

public static class CodeGenerator
{
    private const string TemplatePostfix = "*.jsonmp";

    private static DbContext _dbContext;

    private static string _dataNamespace;

    private const string DefaultTmplateDirectory = "templates";

    private static string _templateDirectory;
    
    private static string _solutionDirectory;

    // private static SchemaExtractor _schemaExtractor;

    // private static readonly HashSet<string> _resourceKeys = new();

    public static void Generate(DbContext dbContext, string templateDirectory = DefaultTmplateDirectory)
    {
        dynamic schemaExtractor = new object();
        Database database = schemaExtractor.Extract(dbContext);

        GenerateCore(database, templateDirectory, dbContext);
    }

    public static void Generate(string modelFilePath, string templateDirectory = DefaultTmplateDirectory)
    {
        JsonSerializerOptions options = new()
                                        {
                                            ReferenceHandler = ReferenceHandler.Preserve
                                        };
        var database = JsonSerializer.Deserialize<Database>(File.ReadAllText(modelFilePath), options);
        
        GenerateCore(database, templateDirectory, null);
    }

    private static void GenerateCore(Database database, string templateDirectory, DbContext dbContext)
    {
        _templateDirectory = templateDirectory;
        _solutionDirectory = Utility.GetSolutionRoot().FullName;

        VariableManager.Instance.Inialize(_templateDirectory, dbContext);

        Console.WriteLine("Generaing templates ...");
        // WriteTemplateText();

        Console.WriteLine("Inflating templates ...");
        InflatePackage(database);

        Console.WriteLine("Finished without error(s)");
    }

    private static void InflatePackage(Database database)
    {
        var templatePathes = Directory
                .GetFiles(_templateDirectory, TemplatePostfix, SearchOption.AllDirectories)
                .Where(x => Path.GetFileName(x).StartsWith("_") == false);

        foreach (var templatePath in templatePathes)
        {
            var templateText = File.ReadAllText(templatePath);
            Template template = Template.Load(templateText);

            Console.WriteLine($"{Path.GetFileName(templatePath)}");

            if (template.Scope == TemplateScope.Database)
            {
                InflatePackageCore(template, database, null);
            }
            else if (template.Scope == TemplateScope.Table)
            {
                foreach (var table in database.Tables)
                    InflatePackageCore(template, database, table);
            }
        }
    }

    private static void InflatePackageCore(Template template, Database database, Table tale)
    {
        var code = Generator.Generate(template.Body, database, tale);
                        
        var pathToWrite = GetPathToWrite(template.TargetPath, tale?.Name??"");
        WriteFileIfNone(pathToWrite, code, template.Overwritable);
        
        Console.WriteLine($"  => {Path.GetFileName(pathToWrite)}");
    }

    private static string GetPathToWrite(string pathToWrite, string tableName)
    {
        if (tableName != null)
            pathToWrite = VariableManager.Instance.Fill(pathToWrite);
        
        var matches = Regex.Matches(pathToWrite, "`(.*?)`");
        foreach (Match match in matches)
            if (match.Value == "`Name`")
                pathToWrite = pathToWrite.Replace(match.Value, tableName);

        // absolute path
        if (pathToWrite.Contains(":") || pathToWrite.StartsWith("/"))
            return pathToWrite;

        return Path.Combine(_solutionDirectory, pathToWrite);
    }

    private static void WriteFileIfNone(string path, string code, bool overwritable)
    {
        if (overwritable == false && File.Exists(path))
            return;
        
        if (Directory.Exists(Path.GetDirectoryName(path)) == false)
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        
        File.WriteAllText(path, code);
    }
}
