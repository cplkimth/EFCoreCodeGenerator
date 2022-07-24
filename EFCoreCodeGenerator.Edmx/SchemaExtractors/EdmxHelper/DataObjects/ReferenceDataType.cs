namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects
{
	public class ReferenceDataType
	{
		/// <summary>
		/// This will take on the name of the Navigation Property Name for Self Referenced Tables
		/// </summary>
		public string TableName { get; set; }

		public string EntityName { get; set; }
		public string EntityNamespace { get; set; }
        public Multiplicity Multiplicity { get; set; }
    }
}
