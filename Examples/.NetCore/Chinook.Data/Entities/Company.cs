
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region CompanyMetadata
public class CompanyMetaData
{
    public int CompanyId {get; set;} 
		public string Name {get; set;} 
}
#endregion

[MetadataType(typeof(CompanyMetaData))]
public partial class Company
{
}

