using System.Collections.Generic;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.SortComparison
{
    public class SortReferences : IComparer<Reference>
    {
        public int Compare(Reference x, Reference y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
