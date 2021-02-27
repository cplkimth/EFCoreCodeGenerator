using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class DatabaseGenerator : DataGenerator
    {
        private readonly Database _database;

        public DatabaseGenerator(Package package, Database database) : base(package)
        {
            _database = database;
        }

        internal override string Generate(Macro macro, string text)
        {
            switch (macro.Value)
            {
                case "Name":
                    return _database.Name;

                case "PascalName":
                    return _database.PascalName;

                case "CamelName":
                    return _database.CamelName;

                case "DataContext":
                    return _database.DataContext;

                default:
                    throw new UnsupportedMacroException(macro, text, this);
            }
        }
    }
}