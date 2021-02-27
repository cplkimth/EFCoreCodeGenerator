using System;
using System.Collections.Generic;
using System.Text;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class TableLoopGenerator : DataGenerator
    {
        private readonly Database _database;

        public TableLoopGenerator(Package package, Database database) : base(package)
        {
            _database = database;
        }

        internal override string Generate(Macro macro, string text)
        {
            List<Table> tables;

            switch (macro.LoopType)
            {
                case LoopType.AL:
                    tables = _database.Tables;
                    break;

                case LoopType.TB:
                    tables = _database.Tables.FindAll(x => x.TableType == TableType.Table);
                    break;

                case LoopType.VW:
                    tables = _database.Tables.FindAll(x => x.TableType == TableType.View);
                    break;

                default:
                    throw new Exception();
            }

            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < tables.Count; i++)
            {
                string code = Build(Package, tables[i].Database, tables[i], null, macro.Value);
                buffer.Append(code);

                if (i != tables.Count - 1)
                {
                    buffer.Append(macro.Seperator);
                }
            }

            return buffer.ToString();
        }
    }
}