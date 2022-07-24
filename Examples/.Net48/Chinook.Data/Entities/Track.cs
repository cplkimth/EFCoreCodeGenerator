
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data
{
    [MetadataType(typeof(TrackMetaData))]
    public partial class Track
    {
    }

    #region TrackMetadata
    public class TrackMetaData
    {
        public Int32 TrackId {get; set;}
		public String Name {get; set;}
		public Int32? AlbumId {get; set;}
		public Boolean BitCol {get; set;}
		public Boolean? BitColNull {get; set;}
		public Byte TinyIntCol {get; set;}
		public Byte? TinyIntColNull {get; set;}
		public Int16 SmallIntCol {get; set;}
		public Int16? SmallIntColNull {get; set;}
		public Int64 BigIntCol {get; set;}
		public Int64? BigIntColNull {get; set;}
		public String CharCol {get; set;}
		public String CharColNull {get; set;}
		public String VarCharCol {get; set;}
		public String VarCharColNull {get; set;}
		public String NcharCol {get; set;}
		public String NcharColNull {get; set;}
		public String NvarCharCol {get; set;}
		public String NvarCharColNull {get; set;}
		public Byte[] BinaryCol {get; set;}
		public Byte[] BinaryColNull {get; set;}
		public DateTime DateCol {get; set;}
		public DateTime? DateColNull {get; set;}
		public DateTime DateTimeCol {get; set;}
		public DateTime? DateTimeColNull {get; set;}
		public DateTime SmallDateTimeCol {get; set;}
		public DateTime? SmallDateTimeColNull {get; set;}
		public Decimal DecimalCol {get; set;}
		public Decimal? DecimalColNull {get; set;}
		public Double FloatCol {get; set;}
		public Double? FloatColNull {get; set;}
		public Single RealCol {get; set;}
		public Single? RealColNull {get; set;}
		public Decimal SmallMoneyCol {get; set;}
		public Decimal? SmallMoneyColNull {get; set;}
		public Byte[] TimeStampCol {get; set;}
		public TimeSpan TimeCol {get; set;}
		public TimeSpan? TimeColNull {get; set;}
		public Guid GuidCol {get; set;}
		public Guid? GuidColNull {get; set;}
		public Byte[] VarBinaryCol {get; set;}
		public Byte[] VarBinaryColNull {get; set;}
    }
    #endregion
}
