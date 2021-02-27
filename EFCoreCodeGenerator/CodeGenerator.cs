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
        public const string TemplatePostfix = "jsonmp";
        public const string PackagePostfix = "json";

        private static DbContext _dbContext;
        private static string _dataDirectoryPath;
        private static string _templateDirectoryPath;

        private static readonly HashSet<string> _resourceKeys = new();

        /// <summary>
        ///     MP 코드를 생성한다.
        /// </summary>
        /// <param name="dbContext">DbContext 객체</param>
        /// <param name="dataDirectoryPath">코드가 생성될 프로젝트의 경로 ex)D:\git\Chinook\Chinook.Data</param>
        /// <param name="templateDirectoryPath">템플릿이 생성될 프로젝트의 경로. 생략하면 실행 디렉토리. ex)C:\git\UsingEntityFrameworkCore\Example\Chinook</param>
        public static void Generate(DbContext dbContext, string dataDirectoryPath, string templateDirectoryPath = null)
        {
            _dbContext = dbContext;
            _dataDirectoryPath = dataDirectoryPath;
            _templateDirectoryPath = templateDirectoryPath??=Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            _templateDirectoryPath = Path.Combine(_templateDirectoryPath, TemplateDirectory);

            LoadResourceKeys();

            Console.WriteLine($"Files will be generated on [{dataDirectoryPath}]");

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
            var packageText = LoadResource(_resourceKeys.FirstOrDefault(x => x.EndsWith(PackagePostfix)));

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
                Value = _dataDirectoryPath
            });

            return package;
        }

        private static void GeneratePackage(Package package)
        {
            var database = SchemaExtractor.Instance.Extract(_dbContext);

            foreach (var resourceKey in _resourceKeys.Where(x => x.EndsWith(TemplatePostfix)))
            {
                var templateText = LoadResource(resourceKey);
                Template template = Template.Load(templateText);

                string pathToWrite = null;
                string code = null;

                if (template.Scope == TemplateScope.Database)
                {
                    pathToWrite = Path.Combine(_dataDirectoryPath, $"{TargetDirectory}", template.TargetPath);
                    code = DataGenerator.Build(package, database, null, null, template.Body);
                    WriteFileIfNone(pathToWrite, code, template.Overwritable);
                }
                else if (template.Scope == TemplateScope.Table)
                {
                    foreach (var table in database.Tables)
                    {
                        pathToWrite = Path.Combine(_dataDirectoryPath, $"{TargetDirectory}", string.Format(template.TargetPath, table.Name));
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

        private static string LoadResource(string fileName)
        {
            string path = Path.Combine(_templateDirectoryPath, fileName.Replace("_", "."));

            var resource = (byte[])Resources.ResourceManager.GetObject(fileName, CultureInfo.CurrentCulture);
            var code = Encoding.UTF8.GetString(resource);
            WriteFileIfNone(path, code);

            return File.ReadAllText(path);
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