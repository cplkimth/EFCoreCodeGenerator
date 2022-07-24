
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(PlaylistMetaData))]
    public partial class Playlist
    {
    }

    #region PlaylistMetadata
    public class PlaylistMetaData
    {
        public Int32 PlaylistId {get; set;}
		public String Name {get; set;}
    }
    #endregion
}
