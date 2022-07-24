
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {
        public string ArtistName { get; set; }

        public int TrackCount { get; set; }

        partial void ToStringCore(ref string value)
        {
            value = $"{AlbumId} / {Title} / {ArtistName} / {TrackCount}";
        }   
    }

    #region AlbumMetadata
    public class AlbumMetaData
    {
        public System.Int32 AlbumId {get; set;}
		public System.Int32 ArtistId {get; set;}
		public System.String Title {get; set;}
    }
    #endregion
}
