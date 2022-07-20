namespace Chinook.WebApiClient;

public partial class ApiClient
{
    public static AuthClient Auth => new(BaseAddress);
}
