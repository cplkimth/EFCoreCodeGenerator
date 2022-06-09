
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace ChinookCore.Data
{
    [MetadataType(typeof(MediaTypeMetaData))]
    public partial class MediaType
    {
    }

    #region MediaTypeMetadata
    public class MediaTypeMetaData
    {
        public int MediaTypeId {get; set;}
		public string Name {get; set;}
    }
    #endregion
}
