
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(PlaylistTrackHistoryMetaData))]
    public partial class PlaylistTrackHistory
    {
    }

    #region PlaylistTrackHistoryMetadata
    public class PlaylistTrackHistoryMetaData
    {
        public System.Int32 PlaylistId {get; set;}
		public System.Int32 TrackId {get; set;}
		public System.DateTime WrittenAt {get; set;}
    }
    #endregion
}
