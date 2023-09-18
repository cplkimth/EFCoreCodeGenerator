
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region PlaylistTrackHistoryMetadata
public class PlaylistTrackHistoryMetaData
{
    public int PlaylistId {get; set;} 
		public int TrackId {get; set;} 
		public DateTime WrittenAt {get; set;} 
}
#endregion

[MetadataType(typeof(PlaylistTrackHistoryMetaData))]
public partial class PlaylistTrackHistory
{
}

