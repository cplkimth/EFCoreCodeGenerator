using System.Collections.Generic;
using EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.SortComparison
{
    public class SortEntities : IComparer<Entity>
    {
        public int Compare(Entity x, Entity y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
