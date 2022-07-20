
#region using
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Chinook.Data;

public partial class AlbumDao
{
    public virtual List<Album> Search(string artistName, string trackName)
    {
        using var context = DbContextFactory.Create();

        var query = from x in context.Albums
            select x;

        if (artistName != null)
            query = query.Where(x => x.Artist.Name.Contains(artistName));

        if (trackName != null)
            query = query.Where(x => x.Tracks.Any(t => t.Name.Contains(trackName)));

        var list = query
            .Select(x => new {Album = x, ArtistName = x.Artist.Name, TrackCount = x.Tracks.Count})
            .ToList();
            
        foreach (var x in list)
        {
            x.Album.ArtistName = x.ArtistName;
            x.Album.TrackCount = x.TrackCount;
        }

        return list.ConvertAll(x => x.Album);
    }
}