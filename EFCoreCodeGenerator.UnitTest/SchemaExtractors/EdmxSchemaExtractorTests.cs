#region usings
using EFCoreCodeGenerator.SchemaExtractors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace EFCoreCodeGenerator.UnitTest.SchemaExtractors;

[TestClass]
public class EdmxSchemaExtractorTests : SchemaExtractorTests
{
    [ClassInitialize]
    public static void Setup(TestContext testContext)
    {
        var schemaExtractor = new EdmxSchemaExtractor(@"Files\Chinook.edmx");
        _database = schemaExtractor.Extract();
    }
}