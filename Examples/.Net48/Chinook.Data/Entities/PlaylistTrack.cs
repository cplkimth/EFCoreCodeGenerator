
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(PlaylistTrackMetaData))]
    public partial class PlaylistTrack
    {
    }

    #region PlaylistTrackMetadata
    public class PlaylistTrackMetaData
    {
        public Int32 PlaylistId {get; set;}
		public Int32 TrackId {get; set;}
		public Boolean? Dummy {get; set;}
    }
    #endregion
}
