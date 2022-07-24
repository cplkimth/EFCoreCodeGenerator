
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(AlbumViewMetaData))]
    public partial class AlbumView
    {
    }

    #region AlbumViewMetadata
    public class AlbumViewMetaData
    {
        public System.Int32 AlbumId {get; set;}
		public System.Int32 ArtistId {get; set;}
		public System.String Title {get; set;}
		public System.String Name {get; set;}
    }
    #endregion
}
