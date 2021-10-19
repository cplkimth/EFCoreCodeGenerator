
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {
        [NotMapped]
        public string ArtistName { get; set; }

        [NotMapped]
        public int TrackCount { get; set; }

        partial void ToStringCore(ref string value)
        {
            value = $"{AlbumId} / {Title} / {ArtistName} / {TrackCount}";
        }     
    }

    #region AlbumMetadata
    public class AlbumMetaData
    {
        public int AlbumId {get; set;}
		public int ArtistId {get; set;}
		public string Title {get; set;}
    }
    #endregion
}
