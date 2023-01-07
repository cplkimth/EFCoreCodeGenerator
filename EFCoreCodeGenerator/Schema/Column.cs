#region usings
using System.Text.Json.Serialization;
#endregion

namespace EFCoreCodeGenerator.Schema;

public class Column : SchemaElement
{
    public Column()
    {
    }

    public Column(Table table, string name)
        : base(name)
    {
        Table = table;
        Table.Columns.Add(this);
    }

    [JsonIgnore]
    public Table Table { get; set; }

    public string Type { get; set; }

    public bool PrimaryKey { get; set; }

    public bool Identity { get; set; }

    public bool ForeignKey { get; set; }

    public bool Nullable { get; set; }

    [JsonIgnore]
    public bool IsCamelName => char.IsLower(Name[0]);

    public override string ToString()
    {
        return $"\t{Type} {Name} [{(PrimaryKey ? "P" : "")} {(Identity ? "I" : "")} {(ForeignKey ? "F" : "")}]";
    }
}