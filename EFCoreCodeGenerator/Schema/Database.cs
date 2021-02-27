#region
using System.Collections.Generic;
using System.Text;
#endregion

namespace EFCoreCodeGenerator.Schema
{
    public class Database : SchemaElement
    {
        public Database(string name)
            : base(name)
        {
            Tables = new List<Table>();
        }

        public string DataContext { get; set; }

        public List<Table> Tables { get; private set; }

        public void SortTables()
        {
            Tables.Sort(CompareTables);
        }

        private int CompareTables(Table x, Table y)
        {
            if (x.TableType != y.TableType)
                return x.TableType.CompareTo(y.TableType);

            return x.Name.CompareTo(y.Name);
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(Name);
            foreach (Table table in Tables)
                buffer.AppendLine("\t" + table);
            buffer.AppendLine();

            return buffer.ToString();
        }
    }
}