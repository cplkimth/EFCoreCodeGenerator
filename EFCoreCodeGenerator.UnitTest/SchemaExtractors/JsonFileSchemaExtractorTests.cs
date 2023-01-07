#region usings
using EFCoreCodeGenerator.SchemaExtractors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace EFCoreCodeGenerator.UnitTest.SchemaExtractors;

[TestClass]
public class JsonFileSchemaExtractorTests : SchemaExtractorTests
{
    [ClassInitialize]
    public static void Setup(TestContext testContext)
    {
        var schemaExtractor = new JsonFileSchemaExtractor(@"Files\Chinook.json");
        _database = schemaExtractor.Extract();
    }
}