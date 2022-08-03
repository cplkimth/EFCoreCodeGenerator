
#region using
using Chinook.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace Chinook.WebApi.Controllers;

#region AlbumController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class AlbumController : ControllerBase
{
    [HttpGet]
    public async Task<List<Album>> GetAsync()
    {
        return await Dao.Album.GetAsync();
    }

    [HttpGet("{albumId}")]
    public async Task<Album> GetByKeyAsync(int albumId)
    {
        return await Dao.Album.GetByKeyAsync(albumId);
    }

    [HttpGet("first")]
    public async Task<Album> GetFirstAsync()
    {
        return await Dao.Album.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Album.GetCountAsync();
    }

    [HttpPost]
    public async Task<Album> InsertAsync(Album entity)
    {
        return await Dao.Album.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Album entity)
    {
        return await Dao.Album.UpdateAsync(entity);
    }

    [HttpDelete("{albumId}")]
    public async Task<int> DeleteByKeyAsync(int albumId)
    {
        return await Dao.Album.DeleteByKeyAsync(albumId);
    }
}
#endregion

#region ArtistController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class ArtistController : ControllerBase
{
    [HttpGet]
    public async Task<List<Artist>> GetAsync()
    {
        return await Dao.Artist.GetAsync();
    }

    [HttpGet("{artistId}")]
    public async Task<Artist> GetByKeyAsync(int artistId)
    {
        return await Dao.Artist.GetByKeyAsync(artistId);
    }

    [HttpGet("first")]
    public async Task<Artist> GetFirstAsync()
    {
        return await Dao.Artist.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Artist.GetCountAsync();
    }

    [HttpPost]
    public async Task<Artist> InsertAsync(Artist entity)
    {
        return await Dao.Artist.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Artist entity)
    {
        return await Dao.Artist.UpdateAsync(entity);
    }

    [HttpDelete("{artistId}")]
    public async Task<int> DeleteByKeyAsync(int artistId)
    {
        return await Dao.Artist.DeleteByKeyAsync(artistId);
    }
}
#endregion

#region CompanyController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class CompanyController : ControllerBase
{
    [HttpGet]
    public async Task<List<Company>> GetAsync()
    {
        return await Dao.Company.GetAsync();
    }

    [HttpGet("{companyId}")]
    public async Task<Company> GetByKeyAsync(int companyId)
    {
        return await Dao.Company.GetByKeyAsync(companyId);
    }

    [HttpGet("first")]
    public async Task<Company> GetFirstAsync()
    {
        return await Dao.Company.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Company.GetCountAsync();
    }

    [HttpPost]
    public async Task<Company> InsertAsync(Company entity)
    {
        return await Dao.Company.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Company entity)
    {
        return await Dao.Company.UpdateAsync(entity);
    }

    [HttpDelete("{companyId}")]
    public async Task<int> DeleteByKeyAsync(int companyId)
    {
        return await Dao.Company.DeleteByKeyAsync(companyId);
    }
}
#endregion

#region PlaylistController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class PlaylistController : ControllerBase
{
    [HttpGet]
    public async Task<List<Playlist>> GetAsync()
    {
        return await Dao.Playlist.GetAsync();
    }

    [HttpGet("{playlistId}")]
    public async Task<Playlist> GetByKeyAsync(int playlistId)
    {
        return await Dao.Playlist.GetByKeyAsync(playlistId);
    }

    [HttpGet("first")]
    public async Task<Playlist> GetFirstAsync()
    {
        return await Dao.Playlist.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Playlist.GetCountAsync();
    }

    [HttpPost]
    public async Task<Playlist> InsertAsync(Playlist entity)
    {
        return await Dao.Playlist.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Playlist entity)
    {
        return await Dao.Playlist.UpdateAsync(entity);
    }

    [HttpDelete("{playlistId}")]
    public async Task<int> DeleteByKeyAsync(int playlistId)
    {
        return await Dao.Playlist.DeleteByKeyAsync(playlistId);
    }
}
#endregion

#region PlaylistTrackController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class PlaylistTrackController : ControllerBase
{
    [HttpGet]
    public async Task<List<PlaylistTrack>> GetAsync()
    {
        return await Dao.PlaylistTrack.GetAsync();
    }

    [HttpGet("{playlistId}/{trackId}")]
    public async Task<PlaylistTrack> GetByKeyAsync(int playlistId, int trackId)
    {
        return await Dao.PlaylistTrack.GetByKeyAsync(playlistId, trackId);
    }

    [HttpGet("first")]
    public async Task<PlaylistTrack> GetFirstAsync()
    {
        return await Dao.PlaylistTrack.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.PlaylistTrack.GetCountAsync();
    }

    [HttpPost]
    public async Task<PlaylistTrack> InsertAsync(PlaylistTrack entity)
    {
        return await Dao.PlaylistTrack.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(PlaylistTrack entity)
    {
        return await Dao.PlaylistTrack.UpdateAsync(entity);
    }

    [HttpDelete("{playlistId}/{trackId}")]
    public async Task<int> DeleteByKeyAsync(int playlistId, int trackId)
    {
        return await Dao.PlaylistTrack.DeleteByKeyAsync(playlistId, trackId);
    }
}
#endregion

#region PlaylistTrackHistoryController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class PlaylistTrackHistoryController : ControllerBase
{
    [HttpGet]
    public async Task<List<PlaylistTrackHistory>> GetAsync()
    {
        return await Dao.PlaylistTrackHistory.GetAsync();
    }

    [HttpGet("{playlistId}/{trackId}/{writtenAt}")]
    public async Task<PlaylistTrackHistory> GetByKeyAsync(int playlistId, int trackId, DateTime writtenAt)
    {
        return await Dao.PlaylistTrackHistory.GetByKeyAsync(playlistId, trackId, writtenAt);
    }

    [HttpGet("first")]
    public async Task<PlaylistTrackHistory> GetFirstAsync()
    {
        return await Dao.PlaylistTrackHistory.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.PlaylistTrackHistory.GetCountAsync();
    }

    [HttpPost]
    public async Task<PlaylistTrackHistory> InsertAsync(PlaylistTrackHistory entity)
    {
        return await Dao.PlaylistTrackHistory.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(PlaylistTrackHistory entity)
    {
        return await Dao.PlaylistTrackHistory.UpdateAsync(entity);
    }

    [HttpDelete("{playlistId}/{trackId}/{writtenAt}")]
    public async Task<int> DeleteByKeyAsync(int playlistId, int trackId, DateTime writtenAt)
    {
        return await Dao.PlaylistTrackHistory.DeleteByKeyAsync(playlistId, trackId, writtenAt);
    }
}
#endregion

#region TrackController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]

public partial class TrackController : ControllerBase
{
    [HttpGet]
    public async Task<List<Track>> GetAsync()
    {
        return await Dao.Track.GetAsync();
    }

    [HttpGet("{trackId}")]
    public async Task<Track> GetByKeyAsync(int trackId)
    {
        return await Dao.Track.GetByKeyAsync(trackId);
    }

    [HttpGet("first")]
    public async Task<Track> GetFirstAsync()
    {
        return await Dao.Track.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Track.GetCountAsync();
    }

    [HttpPost]
    public async Task<Track> InsertAsync(Track entity)
    {
        return await Dao.Track.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Track entity)
    {
        return await Dao.Track.UpdateAsync(entity);
    }

    [HttpDelete("{trackId}")]
    public async Task<int> DeleteByKeyAsync(int trackId)
    {
        return await Dao.Track.DeleteByKeyAsync(trackId);
    }
}
#endregion

#region ControllerHelper
public static class ControllerHelper
{
    public static string GetSubClaimValue(this IEnumerable<Claim> claims) => GetSubClaimValue(claims, x => x);
    
    public static T GetSubClaimValue<T>(this IEnumerable<Claim> claims, Func<string, T> typeConverter)
    {
        var claim = GetClaimValue(claims, JwtRegisteredClaimNames.Sub);

        if (claim == null)
            return default;

        return typeConverter(claim);
    }

    public static string GetClaimValue(this IEnumerable<Claim> claims, string type)
    {
        var claim = claims.FirstOrDefault(x => x.Type == type || x.Properties.Any(y => y.Value == type));

        return claim?.Value;
    }
}
#endregion