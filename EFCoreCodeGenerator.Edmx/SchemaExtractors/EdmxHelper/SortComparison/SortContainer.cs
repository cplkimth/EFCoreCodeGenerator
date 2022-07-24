using System.Collections.Generic;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.SortComparison
{
    public class SortContainer : IComparer<Container>
    {
        public int Compare(Container x, Container y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
