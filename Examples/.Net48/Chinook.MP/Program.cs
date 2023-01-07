using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using EFCoreCodeGenerator;
using EFCoreCodeGenerator.SchemaExtractors;

CodeGenerator.Generate(@"d:\git\EFCoreCodeGenerator\Examples\.Net48\Chinook.Data", "Chinook.Data");
// CodeGenerator.GenerateFromJson(@"d:\git\EFCoreCodeGenerator\Examples\.Net48\Chinook.Data", "Chinook.Data", @"D:\git\EFCoreCodeGenerator\EFCoreCodeGenerator.UnitTest\Files\Chinook.json");
