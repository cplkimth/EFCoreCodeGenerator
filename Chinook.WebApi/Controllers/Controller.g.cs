
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
[Authorize]
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
[Authorize]
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

#region CodeController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class CodeController : ControllerBase
{
    [HttpGet]
    public async Task<List<Code>> GetAsync()
    {
        return await Dao.Code.GetAsync();
    }

    [HttpGet("{codeId}")]
    public async Task<Code> GetByKeyAsync(int codeId)
    {
        return await Dao.Code.GetByKeyAsync(codeId);
    }

    [HttpGet("first")]
    public async Task<Code> GetFirstAsync()
    {
        return await Dao.Code.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Code.GetCountAsync();
    }

    [HttpPost]
    public async Task<Code> InsertAsync(Code entity)
    {
        return await Dao.Code.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Code entity)
    {
        return await Dao.Code.UpdateAsync(entity);
    }

    [HttpDelete("{codeId}")]
    public async Task<int> DeleteByKeyAsync(int codeId)
    {
        return await Dao.Code.DeleteByKeyAsync(codeId);
    }
}
#endregion

#region CodeCategoryController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class CodeCategoryController : ControllerBase
{
    [HttpGet]
    public async Task<List<CodeCategory>> GetAsync()
    {
        return await Dao.CodeCategory.GetAsync();
    }

    [HttpGet("{codeCategory1}")]
    public async Task<CodeCategory> GetByKeyAsync(int codeCategory1)
    {
        return await Dao.CodeCategory.GetByKeyAsync(codeCategory1);
    }

    [HttpGet("first")]
    public async Task<CodeCategory> GetFirstAsync()
    {
        return await Dao.CodeCategory.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.CodeCategory.GetCountAsync();
    }

    [HttpPost]
    public async Task<CodeCategory> InsertAsync(CodeCategory entity)
    {
        return await Dao.CodeCategory.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(CodeCategory entity)
    {
        return await Dao.CodeCategory.UpdateAsync(entity);
    }

    [HttpDelete("{codeCategory1}")]
    public async Task<int> DeleteByKeyAsync(int codeCategory1)
    {
        return await Dao.CodeCategory.DeleteByKeyAsync(codeCategory1);
    }
}
#endregion

#region CustomerController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class CustomerController : ControllerBase
{
    [HttpGet]
    public async Task<List<Customer>> GetAsync()
    {
        return await Dao.Customer.GetAsync();
    }

    [HttpGet("{customerId}")]
    public async Task<Customer> GetByKeyAsync(int customerId)
    {
        return await Dao.Customer.GetByKeyAsync(customerId);
    }

    [HttpGet("first")]
    public async Task<Customer> GetFirstAsync()
    {
        return await Dao.Customer.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Customer.GetCountAsync();
    }

    [HttpPost]
    public async Task<Customer> InsertAsync(Customer entity)
    {
        return await Dao.Customer.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Customer entity)
    {
        return await Dao.Customer.UpdateAsync(entity);
    }

    [HttpDelete("{customerId}")]
    public async Task<int> DeleteByKeyAsync(int customerId)
    {
        return await Dao.Customer.DeleteByKeyAsync(customerId);
    }
}
#endregion

#region EmployeeController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class EmployeeController : ControllerBase
{
    [HttpGet]
    public async Task<List<Employee>> GetAsync()
    {
        return await Dao.Employee.GetAsync();
    }

    [HttpGet("{employeeId}")]
    public async Task<Employee> GetByKeyAsync(int employeeId)
    {
        return await Dao.Employee.GetByKeyAsync(employeeId);
    }

    [HttpGet("first")]
    public async Task<Employee> GetFirstAsync()
    {
        return await Dao.Employee.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Employee.GetCountAsync();
    }

    [HttpPost]
    public async Task<Employee> InsertAsync(Employee entity)
    {
        return await Dao.Employee.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Employee entity)
    {
        return await Dao.Employee.UpdateAsync(entity);
    }

    [HttpDelete("{employeeId}")]
    public async Task<int> DeleteByKeyAsync(int employeeId)
    {
        return await Dao.Employee.DeleteByKeyAsync(employeeId);
    }
}
#endregion

#region InvoiceController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class InvoiceController : ControllerBase
{
    [HttpGet]
    public async Task<List<Invoice>> GetAsync()
    {
        return await Dao.Invoice.GetAsync();
    }

    [HttpGet("{invoiceId}")]
    public async Task<Invoice> GetByKeyAsync(int invoiceId)
    {
        return await Dao.Invoice.GetByKeyAsync(invoiceId);
    }

    [HttpGet("first")]
    public async Task<Invoice> GetFirstAsync()
    {
        return await Dao.Invoice.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.Invoice.GetCountAsync();
    }

    [HttpPost]
    public async Task<Invoice> InsertAsync(Invoice entity)
    {
        return await Dao.Invoice.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(Invoice entity)
    {
        return await Dao.Invoice.UpdateAsync(entity);
    }

    [HttpDelete("{invoiceId}")]
    public async Task<int> DeleteByKeyAsync(int invoiceId)
    {
        return await Dao.Invoice.DeleteByKeyAsync(invoiceId);
    }
}
#endregion

#region InvoiceLineController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public partial class InvoiceLineController : ControllerBase
{
    [HttpGet]
    public async Task<List<InvoiceLine>> GetAsync()
    {
        return await Dao.InvoiceLine.GetAsync();
    }

    [HttpGet("{invoiceLineId}")]
    public async Task<InvoiceLine> GetByKeyAsync(int invoiceLineId)
    {
        return await Dao.InvoiceLine.GetByKeyAsync(invoiceLineId);
    }

    [HttpGet("first")]
    public async Task<InvoiceLine> GetFirstAsync()
    {
        return await Dao.InvoiceLine.GetFirstAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        return await Dao.InvoiceLine.GetCountAsync();
    }

    [HttpPost]
    public async Task<InvoiceLine> InsertAsync(InvoiceLine entity)
    {
        return await Dao.InvoiceLine.InsertAsync(entity);
    }

    [HttpPut]
    public async Task<int> UpdateAsync(InvoiceLine entity)
    {
        return await Dao.InvoiceLine.UpdateAsync(entity);
    }

    [HttpDelete("{invoiceLineId}")]
    public async Task<int> DeleteByKeyAsync(int invoiceLineId)
    {
        return await Dao.InvoiceLine.DeleteByKeyAsync(invoiceLineId);
    }
}
#endregion

#region PlaylistController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
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
[Authorize]
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

#region TrackController
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
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