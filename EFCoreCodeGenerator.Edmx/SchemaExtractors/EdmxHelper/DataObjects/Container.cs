using System.Collections.Generic;

namespace EFCoreCodeGenerator.SchemaExtractors.EdmxHelper.DataObjects
{
	public class Container
	{
		public string Name { get; set; }
		public List<Entity> Entities { get; private set; }
		public List<Entity> Structures { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public Container()
		{
            Entities = new List<Entity>();
			Structures = new List<Entity>();
		}
	}
}
