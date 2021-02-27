#region
using System.Collections.Generic;
#endregion

namespace EFCoreCodeGenerator.Schema
{
    public class Table : SchemaElement
    {
        public Table(Database database, string name) : base(name)
        {
            Database = database;
            Database.Tables.Add(this);

            Columns = new List<Column>();
        }

        public Database Database { get; }

        public List<Column> Columns { get; }

        public TableType TableType
        {
            get { return Columns.Exists(x => x.PrimaryKey) ? TableType.Table : TableType.View; }
        }

        public override string ToString()
        {
            return $"{Name} [{(TableType == TableType.Table ? "T" : "V")}]";
        }
    }
}