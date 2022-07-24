namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects
{
	public class Reference
	{
		public string Name { get; set; }
		public DataType ReferenceType { get; set; }

		public NavigationDataType NavigationType { get; set; }
		public ReferenceDataType SrcDataType { get; set; }
		public ReferenceDataType DstDataType { get; set; }
	}
}
