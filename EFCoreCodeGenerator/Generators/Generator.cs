using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal abstract class Generator
    {
        protected Generator(Package package)
        {
            Package = package;
        }

        protected Package Package { get; private set; }

        internal abstract string Generate(Macro macro, string text);
    }
}