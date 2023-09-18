
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region TodoItemMetadata
public class TodoItemMetaData
{
    public int Id {get; set;} 
		public string Description {get; set;} 
		public bool IsCompleted {get; set;} 
		public string Title {get; set;} 
}
#endregion

[MetadataType(typeof(TodoItemMetaData))]
public partial class TodoItem
{
}

