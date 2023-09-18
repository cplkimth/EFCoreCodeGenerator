#region usings
using System.Text.Json;
using EFCoreCodeGenerator.Schema;
using EFCoreCodeGeneratorV2.Models;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public abstract class SchemaExtractor
{
    public abstract Table[] Extract();
}