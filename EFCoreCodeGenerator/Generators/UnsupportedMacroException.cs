using System;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal class UnsupportedMacroException : Exception
    {
        public char Header { get; set; }
        public Macro Macro { get; private set; }
        public string Text { get; private set; }
        public Generator Generator { get; private set; }

        public UnsupportedMacroException(Macro macro, string text, Generator generator)
        {
            Macro = macro;
            Text = text;
            Generator = generator;
        }

        public UnsupportedMacroException(char header)
        {
            Header = header;
        }
    }
}