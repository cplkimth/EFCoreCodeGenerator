using System.Collections.Generic;
using System.Text;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class ColumnLoopGenerator : DataGenerator
    {
        private readonly Table _table;

        public ColumnLoopGenerator(Package package, Table table) : base(package)
        {
            _table = table;
        }

        internal override string Generate(Macro macro, string text)
        {
            List<Column> columns;

            #region 리스트를 만든다.
            switch (macro.LoopType)
            {
                case LoopType.AL:
                    columns = _table.Columns;
                    break;

                case LoopType.PK:
                    columns = _table.Columns.FindAll(x => x.PrimaryKey);
                    break;

                case LoopType.NP:
                    columns = _table.Columns.FindAll(x => x.PrimaryKey == false);
                    break;

                case LoopType.ID:
                    columns = _table.Columns.FindAll(x => x.Identity);
                    break;

                case LoopType.NI:
                    columns = _table.Columns.FindAll(x => x.Identity == false);
                    break;

                case LoopType.FK:
                    columns = _table.Columns.FindAll(x => x.ForeignKey);
                    break;

                case LoopType.NF:
                    columns = _table.Columns.FindAll(x => x.ForeignKey);
                    break;

                default:
                    throw new UnsupportedMacroException(macro, text, this);
            }
            #endregion

            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < columns.Count; i++)
            {
                string code = Build(Package, _table.Database, _table, columns[i], macro.Value);
                buffer.Append(code);

                if (i != columns.Count - 1)
                {
                    buffer.Append(macro.Seperator);
                }
            }

            return buffer.ToString();
        }
    }
}