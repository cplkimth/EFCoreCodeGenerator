
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


#region TrackMetadata
public class TrackMetaData
{
    public int TrackId {get; set;} 
		public int? AlbumId {get; set;} 
		public long BigIntCol {get; set;} 
		public long? BigIntColNull {get; set;} 
		public byte[] BinaryCol {get; set;} 
		public byte[] BinaryColNull {get; set;} 
		public bool BitCol {get; set;} 
		public bool? BitColNull {get; set;} 
		public string CharCol {get; set;} 
		public string CharColNull {get; set;} 
		public DateTime DateCol {get; set;} 
		public DateTime? DateColNull {get; set;} 
		public DateTime DateTimeCol {get; set;} 
		public DateTime? DateTimeColNull {get; set;} 
		public decimal DecimalCol {get; set;} 
		public decimal? DecimalColNull {get; set;} 
		public double FloatCol {get; set;} 
		public double? FloatColNull {get; set;} 
		public Guid GuidCol {get; set;} 
		public Guid? GuidColNull {get; set;} 
		public string Name {get; set;} 
		public string NcharCol {get; set;} 
		public string NcharColNull {get; set;} 
		public string NvarCharCol {get; set;} 
		public string NvarCharColNull {get; set;} 
		public float RealCol {get; set;} 
		public float? RealColNull {get; set;} 
		public DateTime SmallDateTimeCol {get; set;} 
		public DateTime? SmallDateTimeColNull {get; set;} 
		public short SmallIntCol {get; set;} 
		public short? SmallIntColNull {get; set;} 
		public decimal SmallMoneyCol {get; set;} 
		public decimal? SmallMoneyColNull {get; set;} 
		public TimeSpan TimeCol {get; set;} 
		public TimeSpan? TimeColNull {get; set;} 
		public byte[] TimeStampCol {get; set;} 
		public byte TinyIntCol {get; set;} 
		public byte? TinyIntColNull {get; set;} 
		public byte[] VarBinaryCol {get; set;} 
		public byte[] VarBinaryColNull {get; set;} 
		public string VarCharCol {get; set;} 
		public string VarCharColNull {get; set;} 
}
#endregion

[MetadataType(typeof(TrackMetaData))]
public partial class Track
{
}

