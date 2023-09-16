namespace EFCoreCodeGeneratorV2.Models;

public class Database : BaseModel
{
    public Database()
    {
    }

    public Database(string name) : base(name)
    {
    }

    public override string ToString() => Name;

    public List<Table> Tables { get; init; } = new();
}