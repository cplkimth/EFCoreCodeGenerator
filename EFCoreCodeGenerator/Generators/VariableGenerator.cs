using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class VariableGenerator : DataGenerator
    {
        public VariableGenerator(Package package) : base(package)
        {
        }

        internal override string Generate(Macro macro, string text)
        {
            return Package[macro.Value];
        }
    }
}