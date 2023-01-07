#region usings
using System.Text.Json;
using EFCoreCodeGenerator.Schema;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public abstract class SchemaExtractor
{
    public abstract Database Extract();
}