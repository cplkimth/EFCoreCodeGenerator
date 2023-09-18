
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region ArtistMetadata
public class ArtistMetaData
{
    public int ArtistId {get; set;} 
		public int? CompanyId {get; set;} 
		public string Name {get; set;} 
}
#endregion

[MetadataType(typeof(ArtistMetaData))]
public partial class Artist
{
}

