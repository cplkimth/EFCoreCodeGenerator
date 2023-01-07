#region usings
using System.Collections.Generic;
using System.Text.Json.Serialization;
#endregion

namespace EFCoreCodeGenerator.Schema;

public class Table : SchemaElement
{
    public Table()
    {
    }

    public Table(Database database, string name) : base(name)
    {
        Database = database;
        Database.Tables.Add(this);
    }

    [JsonIgnore]
    public Database Database { get; }

    public List<Column> Columns { get; set; } = new();

    [JsonIgnore]
    public TableType TableType
    {
        get { return Columns.Exists(x => x.PrimaryKey) ? TableType.Table : TableType.View; }
    }

    public override string ToString()
    {
        return $"{Name} [{(TableType == TableType.Table ? "T" : "V")}]";
    }
}