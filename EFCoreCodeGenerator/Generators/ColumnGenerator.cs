using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class ColumnGenerator : DataGenerator
    {
        private readonly Column _column;

        public ColumnGenerator(Package package, Column column) : base(package)
        {
            _column = column;
        }

        internal override string Generate(Macro macro, string text)
        {
            switch (macro.Value)
            {
                case "Name":
                    return _column.Name;

                case "PascalName":
                    return _column.PascalName;

                case "CamelName":
                    return _column.CamelName;

                case "Type":
                    return _column.Type;

                default:
                    throw new UnsupportedMacroException(macro, text, this);
            }
        }
    }
}