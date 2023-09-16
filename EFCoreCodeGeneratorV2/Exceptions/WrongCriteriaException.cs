using System;

namespace EFCoreCodeGenerator.Exceptions
{
    internal class WrongCriteriaException : Exception
    {
        public string Criteria { get; private set; }

        public WrongCriteriaException(string criteria) : base(string.Format("criteria {0} is wrong.", criteria))
        {
            Criteria = criteria;
        }
    }
}