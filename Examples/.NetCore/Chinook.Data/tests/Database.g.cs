

public partial class _Album
{
	// A : 
	public int AlbumId {get; set;}
	public int ArtistId {get; set;}
	public string Title {get; set;}
	
	// P : 
	public int AlbumIdKey {get; set;}
	
}

public partial class _Artist
{
	// A : 
	public int ArtistId {get; set;}
	public int? CompanyId {get; set;}
	public string Name {get; set;}
	
	// P : 
	public int ArtistIdKey {get; set;}
	
}

public partial class _Company
{
	// A : 
	public int CompanyId {get; set;}
	public string Name {get; set;}
	
	// P : 
	public int CompanyIdKey {get; set;}
	
}

public partial class _Playlist
{
	// A : 
	public int PlaylistId {get; set;}
	public string Name {get; set;}
	
	// P : 
	public int PlaylistIdKey {get; set;}
	
}

public partial class _PlaylistTrack
{
	// A : 
	public int PlaylistId {get; set;}
	public int TrackId {get; set;}
	public bool? Dummy {get; set;}
	
	// P : 
	public int PlaylistIdKey {get; set;}
	public int TrackIdKey {get; set;}
	
}

public partial class _PlaylistTrackHistory
{
	// A : 
	public int PlaylistId {get; set;}
	public int TrackId {get; set;}
	public DateTime WrittenAt {get; set;}
	
	// P : 
	public int PlaylistIdKey {get; set;}
	public int TrackIdKey {get; set;}
	public DateTime WrittenAtKey {get; set;}
	
}

public partial class _Track
{
	// A : 
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
	
	// P : 
	public int TrackIdKey {get; set;}
	
}


 public partial class _Album {} 
 public partial class _Artist {} 
 public partial class _Company {} 
 public partial class _Playlist {} 
 public partial class _PlaylistTrack {} 
 public partial class _PlaylistTrackHistory {} 
 public partial class _Track {} 
