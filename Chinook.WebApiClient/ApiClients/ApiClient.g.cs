
using System.Text.Json;

namespace Chinook.WebApiClient;

public partial class ApiClient
{
    public const string Authorization = "Authorization";
    public const string Bearer = "Bearer";

    public static string JwtToken { get; set; }

    public static string BaseAddress { get; set; }

    #region clients
    public static AlbumClient Album => new AlbumClient(BaseAddress);
public static ArtistClient Artist => new ArtistClient(BaseAddress);
public static CodeClient Code => new CodeClient(BaseAddress);
public static CodeCategoryClient CodeCategory => new CodeCategoryClient(BaseAddress);
public static CustomerClient Customer => new CustomerClient(BaseAddress);
public static EmployeeClient Employee => new EmployeeClient(BaseAddress);
public static InvoiceClient Invoice => new InvoiceClient(BaseAddress);
public static InvoiceLineClient InvoiceLine => new InvoiceLineClient(BaseAddress);
public static PlaylistClient Playlist => new PlaylistClient(BaseAddress);
public static PlaylistTrackClient PlaylistTrack => new PlaylistTrackClient(BaseAddress);
public static TrackClient Track => new TrackClient(BaseAddress);
    #endregion

    public static void AddAuthorizationToken(HttpClient client)
    {
        client.DefaultRequestHeaders.Add(Authorization, $"{Bearer} {JwtToken}");
    }
}

public partial class BaseClient
{
    partial void UseJsonSerializerOptions(JsonSerializerOptions settings);

    protected virtual void SetJsonSerializerOptions(JsonSerializerOptions settings)
    {
        UseJsonSerializerOptions(settings);
    }
}

#region clients
public partial class AlbumClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class ArtistClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class CodeClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class CodeCategoryClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class CustomerClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class EmployeeClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class InvoiceClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class InvoiceLineClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class PlaylistClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class PlaylistTrackClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}

public partial class TrackClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);

    partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => SetJsonSerializerOptions(settings);
}
#endregion