
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(GenreMetaData))]
    public partial class Genre
    {
    }

    #region GenreMetadata
    public class GenreMetaData
    {
        public int GenreId {get; set;}
		public string Name {get; set;}
    }
    #endregion
}
