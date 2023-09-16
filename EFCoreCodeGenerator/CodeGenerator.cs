#region
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Generators;
using EFCoreCodeGenerator.Properties;
using EFCoreCodeGenerator.Schema;
using EFCoreCodeGenerator.SchemaExtractors;
using Microsoft.EntityFrameworkCore;
#endregion

namespace EFCoreCodeGenerator;

public static class CodeGenerator
{
    private const string TemplatePostfix = "*.jsonmp";
    private const string PackageFileName = "Package.json";

    private static string _dataProjectPath;

    private static Version _version;

    private static DbContext _dbContext;

    private static string _dataNamespace;

    private static string _templateDirectoryPath;

    private static SchemaExtractor _schemaExtractor;

    // private static readonly HashSet<string> _resourceKeys = new();

    /// <summary>
    ///     MP 코드를 생성한다.
    /// </summary>
    /// <param name="dataProjectPath">Data 코드가 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data</param>
    /// <param name="dbContext">DbContext 객체</param>
    /// <param name="templateDirectory">템플릿이 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP</param>
    public static void Generate(string dataProjectPath, DbContext dbContext, string templateDirectory = "templates") 
        => GenerateCore(dataProjectPath, dbContext, null, templateDirectory, null);

    /// <summary>
    ///     MP 코드를 생성한다.
    /// </summary>
    /// <param name="dataProjectPath">Data 코드가 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data</param>
    /// <param name="dataNamespace">데이터 프로젝트 네임스페이스</param>
    /// <param name="templateDirectory">템플릿이 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP</param>
    public static void Generate(string dataProjectPath, string dataNamespace, string templateDirectory = "templates") 
        => GenerateCore(dataProjectPath, null, dataNamespace, templateDirectory, null);

    /// <summary>
    ///     MP 코드를 생성한다.
    /// </summary>
    /// <param name="dataProjectPath">Data 코드가 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data</param>
    /// <param name="dataNamespace">데이터 프로젝트 네임스페이스</param>
    /// <param name="jsonPath">스키마 JSON 파일 경로</param>
    /// <param name="templateDirectory">템플릿이 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP</param>
    public static void GenerateFromJson(string dataProjectPath, string dataNamespace, string jsonPath, string templateDirectory = "templates") 
        => GenerateCore(dataProjectPath, null, dataNamespace, templateDirectory, jsonPath);

    private static void GenerateCore(string dataProjectPath, DbContext dbContext, string dataNamespace, string templateDirectory, string jsonPath)
    {
        _dataProjectPath = dataProjectPath;
        _dataNamespace = dataNamespace;
        _templateDirectoryPath = Path.Combine(_dataProjectPath, templateDirectory);

        if (dbContext != null)
        {
            _dbContext = dbContext;
            _schemaExtractor = new DbContextSchemaExtractor(_dbContext);
        }
        else if (jsonPath != null)
        {
            _schemaExtractor = new JsonFileSchemaExtractor(jsonPath);
        }
        else
        {
            var edmxPath = Directory.GetFiles(_dataProjectPath, "*.edmx").FirstOrDefault();
            _schemaExtractor = new EdmxSchemaExtractor(edmxPath);
        }

        _version = _dbContext switch
        {
            null => Version.EF6,
            _ => Version.Core
        };

        Console.WriteLine($"Files will be generated on [{dataProjectPath}]");
        Console.WriteLine($"with templates in [{_templateDirectoryPath}]");
        Console.WriteLine($"using {_schemaExtractor.GetType().Name}.");

        Console.WriteLine("Generaing templates ...");
        // WriteTemplateText();

        Console.WriteLine("Loading package");
        var package = LoadPackage();

        Console.WriteLine("Inflating templates ...");
        InflatePackage(package);

        Console.WriteLine("Finished without error(s)");
    }

    private static void WriteTemplateText()
    {
        var resourceKeys = new HashSet<string>();

        foreach (DictionaryEntry entry in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
        {
            var fileName = (string)entry.Key;
            resourceKeys.Add(fileName);
        }

        var inversedVersion = _version == Version.Core ? Version.EF6 : Version.Core;

        resourceKeys.RemoveWhere(x => x.StartsWith(inversedVersion.ToString()));

        foreach (var resourceKey in resourceKeys)
        {
            string extension = resourceKey switch
            {
                "Package" => ".json",
                _ => ".jsonmp"
            };
            string templatePath = Path.Combine(_templateDirectoryPath, resourceKey) + extension;

            if (File.Exists(templatePath))
                continue;

            var resource = (byte[])Resources.ResourceManager.GetObject(resourceKey, CultureInfo.CurrentCulture);
            var templateText = Encoding.UTF8.GetString(resource);
            WriteFileIfNone(templatePath, templateText, false);

            Console.WriteLine($"\t[{Path.GetFileNameWithoutExtension(templatePath)}] has generated at {templatePath}.");
        }
    }

    private static Package LoadPackage()
    {
        var packageText = File.ReadAllText(Path.Combine(_templateDirectoryPath, PackageFileName));

        if (packageText == null)
            throw new FileNotFoundException("[Package].json file does NOT exist!");

        var package = JsonSerializer.Deserialize<Package>(packageText);

        package.Variables.Add(new Variable
                              {
                                  Name = "DataNamespace",
                                  Value = _dbContext == null ? _dataNamespace : _dbContext.GetType().Namespace
                              });

        package.Variables.Add(new Variable
                              {
                                  Name = "DataDirectory",
                                  Value = _dataProjectPath
                              });

        return package;
    }

    private static void InflatePackage(Package package)
    {
        var database = _schemaExtractor.Extract();

        var templatePathes = Directory.GetFiles(_templateDirectoryPath, TemplatePostfix, SearchOption.AllDirectories);
        foreach (var templatePath in templatePathes)
        {
            if (Path.GetFileName(templatePath).StartsWith("_"))
                continue;

            var templateText = File.ReadAllText(templatePath);
            Template template = Template.Load(templateText);

            Console.WriteLine($"{Path.GetFileName(templatePath)}");

            string pathToWrite = null;
            string code = null;

            if (template.Scope == TemplateScope.Database)
            {
                pathToWrite = GetPathToWrite(template.TargetPath);
                code = DataGenerator.Build(package, database, null, null, template.Body);
                    
                WriteFileIfNone(pathToWrite, code, template.Overwritable);
                Console.WriteLine($"  => {Path.GetFileName(pathToWrite)}");
            }
            else if (template.Scope == TemplateScope.Table)
            {
                foreach (var table in database.Tables)
                {
                    pathToWrite = GetPathToWrite(string.Format(template.TargetPath, table.Name));
                    code = DataGenerator.Build(package, database, table, null, template.Body);
                        
                    WriteFileIfNone(pathToWrite, code, template.Overwritable);
                    Console.WriteLine($"  => {Path.GetFileName(pathToWrite)}");
                }
            }
            else
            {
                throw new NotImplementedException("CodeGenerator.InflatePackage");
            }
        }
    }

    private static string GetPathToWrite(string pathToWrite)
    {
        if (pathToWrite.Contains(":") is false) // drive
            pathToWrite = Path.Combine(_dataProjectPath, pathToWrite);

        return pathToWrite;
    }

    private static void WriteFileIfNone(string path, string code, bool overwritable)
    {
        if (overwritable == false && File.Exists(path))
            return;

        if (Directory.Exists(Path.GetDirectoryName(path)) == false)
            Directory.CreateDirectory(Path.GetDirectoryName(path));

        File.WriteAllText(path, code);
    }

    enum Version
    {
        EF6,
        Core
    }
}
