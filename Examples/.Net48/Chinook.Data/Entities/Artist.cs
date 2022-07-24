
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(ArtistMetaData))]
    public partial class Artist
    {
    }

    #region ArtistMetadata
    public class ArtistMetaData
    {
        public Int32 ArtistId {get; set;}
		public String Name {get; set;}
		public Int32? CompanyId {get; set;}
    }
    #endregion
}
