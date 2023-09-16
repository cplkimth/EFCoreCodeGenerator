using EFCoreCodeGenerator.Exceptions;

namespace EFCoreCodeGeneratorV2.Models;

public class Table : BaseModel
{
    public Table()
    {
    }

    public Table(string name) : base(name)
    {
    }

    public override string ToString() => Name;

    public List<Column> Columns { get; init; } = new();

    public void Add(params Column[] columns)
    {
        foreach (var node in columns)
        {
            node.Table = this;
            Columns.Add(node);
        }
    }

    public List<Column> Search(string criteria)
    {
        return criteria switch
        {
            "A" => Columns,
            "P" => Columns.FindAll(x => x.PK),
            "F" => Columns.FindAll(x => x.FK),
            "I" => Columns.FindAll(x => x.ID),
            "N" => Columns.FindAll(x => x.Null),
            "!A" => new List<Column>(),
            "!P" => Columns.FindAll(x => x.PK is false),
            "!F" => Columns.FindAll(x => x.FK is false),
            "!I" => Columns.FindAll(x => x.ID is false),
            "!N" => Columns.FindAll(x => x.Null is false),
            _ => throw new WrongCriteriaException(criteria)
        };
    }
}