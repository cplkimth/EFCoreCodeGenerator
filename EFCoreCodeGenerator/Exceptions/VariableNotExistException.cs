using System;

namespace EFCoreCodeGenerator.Exceptions
{
    internal class VariableNotExistException : Exception
    {
        public string Variable { get; private set; }

        public VariableNotExistException(string variable) : base(string.Format("variable {0} is not exist.", variable))
        {
            Variable = variable;
        }
    }
}