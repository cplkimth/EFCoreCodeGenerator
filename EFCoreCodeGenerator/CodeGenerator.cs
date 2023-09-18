#region usings
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Models;
using EFCoreCodeGenerator.SchemaExtractors;
using EFCoreCodeGenerator.Utilities;
using Microsoft.EntityFrameworkCore;
#endregion

namespace EFCoreCodeGenerator;

public static class CodeGenerator
{
    private const string TemplatePostfix = "*.jsonmp";

    private const string DefaultTmplateDirectory = "templates";

    private static string _templateDirectory;

    private static string _solutionDirectory;

    public static string Generate(DbContext dbContext, string templateDirectory = DefaultTmplateDirectory)
    {
        var schemaExtractor = new DbContextSchemaExtractor(dbContext);

        return GenerateCore(schemaExtractor, templateDirectory, dbContext);
    }

    public static string Generate(string modelFilePath, string templateDirectory = DefaultTmplateDirectory)
    {
        var schemaExtractor = new JsonFileSchemaExtractor(modelFilePath);

        return GenerateCore(schemaExtractor, templateDirectory, null);
    }

    private static string GenerateCore(SchemaExtractor schemaExtractor, string templateDirectory, DbContext dbContext)
    {
        _templateDirectory = templateDirectory;
        _solutionDirectory = Utility.GetSolutionRoot().FullName;

        VariableManager.Instance.Inialize(_templateDirectory, dbContext);

        var tables = schemaExtractor.Extract();

        Console.WriteLine("Generaing templates ...");
        // WriteTemplateText();

        Console.WriteLine("Inflating templates ...");
        InflatePackage(tables);

        Console.WriteLine("Finished without error(s)");

        return JsonSerializer.Serialize(tables);
    }

    private static void InflatePackage(Table[] tables)
    {
        var templatePathes = Directory
            .GetFiles(_templateDirectory, TemplatePostfix, SearchOption.AllDirectories)
            .Where(x => Path.GetFileName((string) x).StartsWith("_") == false);

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