#region usings
#endregion

using EFCoreCodeGenerator.Models;

namespace EFCoreCodeGenerator.SchemaExtractors;

public abstract class SchemaExtractor
{
    public abstract Table[] Extract();
}