using System.Collections.Generic;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.SortComparison
{
    public class SortScalars : IComparer<Scalar>
    {
        public int Compare(Scalar x, Scalar y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
