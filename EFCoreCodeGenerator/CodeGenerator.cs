#region usings
using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Models;
using EFCoreCodeGenerator.Properties;
using EFCoreCodeGenerator.SchemaExtractors;
using EFCoreCodeGenerator.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
#endregion

namespace EFCoreCodeGenerator;

public static class CodeGenerator
{
    private const string TemplatePostfix = ".jsonmp";
    
    private static string _templateDirectoryPath;

    private static string _solutionDirectoryPath;

    public static string Generate(DbContext dbContext, [CallerFilePath] string templateDirectoryPath = null)
    {
        var schemaExtractor = new DbContextSchemaExtractor(dbContext);

        return GenerateCore(schemaExtractor, templateDirectoryPath, dbContext);
    }

    public static string Generate(string modelFilePath, [CallerFilePath] string templateDirectoryPath = null)
    {
        var schemaExtractor = new JsonFileSchemaExtractor(modelFilePath);

        return GenerateCore(schemaExtractor, templateDirectoryPath, null);
    }

    private static string GenerateCore(SchemaExtractor schemaExtractor, string templateDirectoryPath, DbContext dbContext)
    {
        if (Directory.Exists(templateDirectoryPath) == false)
        {
            _templateDirectoryPath = Utility.GetTemplateDirectory(templateDirectoryPath);

            if (Directory.Exists(_templateDirectoryPath) == false)
            {
                Console.WriteLine("Generaing templates ...");
                WriteTemplateText();
            }
        }
        else
        {
            _templateDirectoryPath = templateDirectoryPath;
        }

        _solutionDirectoryPath = Utility.GetSolutionRoot().FullName;

        VariableManager.Instance.Inialize(_templateDirectoryPath, dbContext);

        var tables = schemaExtractor.Extract();

        Console.WriteLine("Inflating templates ...");
        InflatePackage(tables);

        Console.WriteLine("Finished without error(s)");

        return JsonSerializer.Serialize(tables);
    }

    private static void WriteTemplateText()
    {
        var resourceKeys = new HashSet<string>();

        foreach (DictionaryEntry entry in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
        {
            var fileName = (string)entry.Key;
            resourceKeys.Add(fileName);
        }

        foreach (var resourceKey in resourceKeys)
        {
            string extension = resourceKey switch
            {
                "Variables" => ".json",
                _ => TemplatePostfix
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

    private static void InflatePackage(Table[] tables)
    {
        var templatePathes = Directory
            .GetFiles(_templateDirectoryPath, $"*{TemplatePostfix}", SearchOption.AllDirectories)
            .Where(x => Path.GetFileName(x).StartsWith("_") == false);

        foreach (var templatePath in templatePathes)
        {
            var templateText = File.ReadAllText(templatePath);
            var template = Template.Load(templateText);

            Console.WriteLine($"{Path.GetFileName(templatePath)}");

            if (template.Scope == TemplateScope.Database)
                InflatePackageCore(template, tables.ToArray());
            else if (template.Scope == TemplateScope.Table)
                foreach (var table in tables)
                    InflatePackageCore(template, table);
        }
    }

    private static void InflatePackageCore(Template template, params Table[] tables)
    {
        var code = Generator.Generate(template.Body, tables);

        var pathToWrite = GetPathToWrite(template.TargetPath, tables.Length > 0 ? tables[0].Name : "");
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

        return Path.Combine(_solutionDirectoryPath, pathToWrite);
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