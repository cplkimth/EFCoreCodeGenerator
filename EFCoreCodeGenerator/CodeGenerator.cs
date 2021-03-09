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
using EFCoreCodeGenerator.SchemaExtractors;
using Microsoft.EntityFrameworkCore;
#endregion

namespace EFCoreCodeGenerator
{
    public class CodeGenerator
    {
        private const string TargetDirectory = "UEF";
        private const string TemplateDirectory = "templates";
        private const string TemplatePostfix = "jsonmp";
        private const string PackagePostfix = "json";

        private static DbContext _dbContext;
        private static string _dataProjectPath;
        private static string _templateDirectoryPath;

        private static readonly HashSet<string> _resourceKeys = new();

        /// <summary>
        ///     MP 코드를 생성한다.
        /// </summary>
        /// <param name="dbContext">DbContext 객체</param>
        /// <param name="dataProjectPath">코드가 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data</param>
        /// <param name="templateProjectPath">템플릿이 생성될 프로젝트의 경로. ex)C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP</param>
        public static void Generate(DbContext dbContext, string dataProjectPath, string templateProjectPath)
        {
            _dbContext = dbContext;
            _dataProjectPath = dataProjectPath;
            // _templateProjectPath = templateProjectPath??=Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            if (templateProjectPath != null)
                _templateDirectoryPath = Path.Combine(templateProjectPath, TemplateDirectory);

            LoadResourceKeys();

            Console.WriteLine($"Files will be generated on [{dataProjectPath}]");

            var package = LoadPackage();
            GeneratePackage(package);

            Console.WriteLine("Finished without error(s)");
        }

        private static void LoadResourceKeys()
        {
            _resourceKeys.Clear();

            foreach (DictionaryEntry entry in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                var fileName = (string)entry.Key;
                _resourceKeys.Add(fileName);
            }
        }

        private static Package LoadPackage()
        {
            var packageText = ReadTemplateText(_resourceKeys.FirstOrDefault(x => x.EndsWith(PackagePostfix)));

            if (packageText == null)
                throw new FileNotFoundException("[Package].json file does NOT exist!");

            var package = JsonSerializer.Deserialize<Package>(packageText);

            package.Variables.Add(new Variable
            {
                Name = "DataNamespace",
                Value = _dbContext.GetType().Namespace
            });

            package.Variables.Add(new Variable
            {
                Name = "DataDirectory",
                Value = _dataProjectPath
            });

            return package;
        }

        private static void GeneratePackage(Package package)
        {
            var database = SchemaExtractor.Instance.Extract(_dbContext);

            foreach (var resourceKey in _resourceKeys.Where(x => x.EndsWith(TemplatePostfix)))
            {
                var templateText = ReadTemplateText(resourceKey);
                Template template = Template.Load(templateText);

                string pathToWrite = null;
                string code = null;

                if (template.Scope == TemplateScope.Database)
                {
                    pathToWrite = Path.Combine(_dataProjectPath, $"{TargetDirectory}", template.TargetPath);
                    code = DataGenerator.Build(package, database, null, null, template.Body);
                    WriteFileIfNone(pathToWrite, code, template.Overwritable);
                }
                else if (template.Scope == TemplateScope.Table)
                {
                    foreach (var table in database.Tables)
                    {
                        pathToWrite = Path.Combine(_dataProjectPath, $"{TargetDirectory}", string.Format(template.TargetPath, table.Name));
                        code = DataGenerator.Build(package, database, table, null, template.Body);
                        WriteFileIfNone(pathToWrite, code);
                    }
                }
                else
                {
                    throw new NotImplementedException("CodeGenerator.GeneratePackage");
                }
            }
        }

        private static string ReadTemplateText(string resourceKey)
        {
            string templatePath = Path.Combine(_templateDirectoryPath, resourceKey.Replace("_", "."));

            var resource = (byte[])Resources.ResourceManager.GetObject(resourceKey, CultureInfo.CurrentCulture);
            var templateText = Encoding.UTF8.GetString(resource);
            WriteFileIfNone(templatePath, templateText);

            return File.ReadAllText(templatePath);
        }

        private static void WriteFileIfNone(string path, string code, bool overwritable = false)
        {
            if (overwritable == false && File.Exists(path))
                return;

            if (Directory.Exists(Path.GetDirectoryName(path)) == false)
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            File.WriteAllText(path, code);
        }
    }
}