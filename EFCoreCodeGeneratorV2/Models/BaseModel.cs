#region usings
using System.Text.Json.Serialization;
#endregion

namespace EFCoreCodeGeneratorV2.Models;

public abstract class BaseModel
{
    protected BaseModel()
    {
    }

    protected BaseModel(string name)
    {
        Name = name;
    }

    public string Name { get; init; }

    [JsonIgnore]
    public string PascalName => Name[..1].ToUpper() + Name[1..];

    [JsonIgnore]
    public string CamelName => Name[..1].ToLower() + Name[1..];
}