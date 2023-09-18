
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region PlaylistTrackMetadata
public class PlaylistTrackMetaData
{
    public int PlaylistId {get; set;} 
		public int TrackId {get; set;} 
		public bool? Dummy {get; set;} 
}
#endregion

[MetadataType(typeof(PlaylistTrackMetaData))]
public partial class PlaylistTrack
{
}

