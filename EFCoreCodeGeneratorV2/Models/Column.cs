namespace EFCoreCodeGeneratorV2.Models;

public class Column : BaseModel
{
    public Column()
    {
    }

    public Column(string name, string type) : base(name)
    {
        Type = type;
    }

    public override string ToString() => $"{Type} {Name} ({(PK ? "P":"_")}{(FK ? "F":"_")}{(ID ? "I":"_")}{(Null ? "N":"_")})";

    public Table Table { get; set; }

    public string Type { get; init; }
    public bool PK { get; init; }
    public bool ID { get; init; }
    public bool FK { get; init; }
    public bool Null { get; init; }
}