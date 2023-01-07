#region usings
using System.IO;
using System.Text.Json;
using EFCoreCodeGenerator.Schema;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public class JsonFileSchemaExtractor : SchemaExtractor
{
    private readonly string _jsonFilePath;

    public JsonFileSchemaExtractor(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public override Database Extract()
    {
        var json = File.ReadAllText(_jsonFilePath);
        var database = JsonSerializer.Deserialize<Database>(json);

        return database;
    }
}