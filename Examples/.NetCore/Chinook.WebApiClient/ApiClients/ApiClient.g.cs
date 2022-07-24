
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
public static CompanyClient Company => new CompanyClient(BaseAddress);
public static PlaylistClient Playlist => new PlaylistClient(BaseAddress);
public static PlaylistTrackClient PlaylistTrack => new PlaylistTrackClient(BaseAddress);
public static PlaylistTrackHistoryClient PlaylistTrackHistory => new PlaylistTrackHistoryClient(BaseAddress);
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

public partial class CompanyClient
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

public partial class PlaylistTrackHistoryClient
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