
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region PlaylistMetadata
public class PlaylistMetaData
{
    public int PlaylistId {get; set;} 
		public string Name {get; set;} 
}
#endregion

[MetadataType(typeof(PlaylistMetaData))]
public partial class Playlist
{
}

