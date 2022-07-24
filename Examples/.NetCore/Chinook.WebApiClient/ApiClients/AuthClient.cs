namespace Chinook.WebApiClient;

public partial class AuthClient
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => ApiClient.AddAuthorizationToken(client);
}