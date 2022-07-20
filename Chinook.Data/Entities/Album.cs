
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;

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