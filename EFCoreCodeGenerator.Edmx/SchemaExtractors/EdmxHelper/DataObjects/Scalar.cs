using System.Collections.Generic;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects
{
	public class Scalar
	{
	    public Scalar()
        {
            Facets = new Dictionary<string, object>();
        }

	    public string Name { get; set; }
		public bool IsKey { get; set; }
		public DataType ScalarType { get; set; }
		public object DefaultValue { get; set; }

        public Dictionary<string, object> Facets { get; private set; }
        public int? MaxLength { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }

	    public bool Identity { get; set; }
	    public bool ForeignKey { get; set; }
	    public bool Nullable { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, K:{1}, I:{2}, F:{3}, N:{4}", Name, IsKey, Identity, ForeignKey, Nullable);
        }
	}
}
