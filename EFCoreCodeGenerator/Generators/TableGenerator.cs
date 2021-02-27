using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class TableGenerator : DataGenerator
    {
        private readonly Table _table;

        public TableGenerator(Package package, Table table) : base(package)
        {
            _table = table;
        }

        internal override string Generate(Macro macro, string text)
        {
            switch (macro.Value)
            {
                case "Name":
                    return _table.Name;

                case "PascalName":
                    return _table.PascalName;

                case "CamelName":
                    return _table.CamelName;

                case "BeginOnView":
                    return _table.TableType == TableType.Table ? string.Empty : "/* not available for view";

                case "EndOnView":
                    return _table.TableType == TableType.Table ? string.Empty : "*/";

                default:
                    throw new UnsupportedMacroException(macro, text, this);
            }
        }
    }
}