using System.Collections.Generic;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects
{
    public class Entity
    {
        public string SetName { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string BaseName { get; set; }
        public string BaseNamespace { get; set; }
        public bool IsAbstract { get; set; }

        public List<Scalar> Keys { get; private set; }
        public List<Scalar> Scalars { get; private set; }
        public List<Reference> SingleReferences { get; private set; }
        public List<Reference> MultipleReferences { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Entity()
        {
            Keys = new List<Scalar>();
            Scalars = new List<Scalar>();
            SingleReferences = new List<Reference>();
            MultipleReferences = new List<Reference>();
        }

        public List<Scalar> GetProperties()
        {
            var list = new List<Scalar>(Keys);
            list.AddRange(Scalars);

            return list;
        }
    }
}
