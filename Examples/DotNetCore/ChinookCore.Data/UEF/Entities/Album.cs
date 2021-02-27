
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
 
#endregion

namespace ChinookCore.Data
{
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
}
