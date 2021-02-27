using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class CommentGenerator : DataGenerator
    {
        public CommentGenerator(Package package) : base(package)
        {
        }

        internal override string Generate(Macro macro, string text)
        {
            return string.Empty;
        }
    }
}