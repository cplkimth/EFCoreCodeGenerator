

public partial class _Album
{
	// A : 
	public int AlbumId {get; set;}
	public string Title {get; set;}
	public int ArtistId {get; set;}
	
	// P : 
	public int AlbumIdKey {get; set;}
	
}


public partial class _Track
{
	// A : 
	public int TrackId {get; set;}
	public string Name {get; set;}
	public int AlbumId {get; set;}
	public Guid? GuidColNull {get; set;}
	
	// P : 
	public int TrackIdKey {get; set;}
	
}


public partial class _PlaylistTrack
{
	// A : 
	public int PlaylistId {get; set;}
	public int TrackId {get; set;}
	public string Memo {get; set;}
	
	// P : 
	public int PlaylistIdKey {get; set;}
	public int TrackIdKey {get; set;}
	
}



 public partial class _Album {} 
 public partial class _Track {} 
 public partial class _PlaylistTrack {} 
