
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(ArtistMetaData))]
    public partial class Artist
    {
    }

    #region ArtistMetadata
    public class ArtistMetaData
    {
        public int ArtistId {get; set;}
		public string Name {get; set;}
    }
    #endregion
}
