using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using EFCoreCodeGenerator;
using EFCoreCodeGenerator.SchemaExtractors;

CodeGenerator.Generate(@"C:\git\EFCoreCodeGenerator\Examples\.Net48\Chinook.Data", "Chinook.Data");
return;
var database = EdmxSchemaExtractor.Instance.Extract(@"C:\git\EFCoreCodeGenerator\Examples\.Net48\Chinook.Data\Chinook.edmx");

var json = JsonSerializer.Serialize(database);
Console.WriteLine(json);
File.WriteAllText(@"C:\t\MidnightPeach\MidnightPeach\mp2.json", json);
