
namespace Chinook.WebApiClient;

public class Counter
{
    public static void Print()
    {
                Console.WriteLine($"Album : {ApiClient.Album.GetCountAsync().Result:N0}");
        Console.WriteLine($"Artist : {ApiClient.Artist.GetCountAsync().Result:N0}");
        Console.WriteLine($"Company : {ApiClient.Company.GetCountAsync().Result:N0}");
        Console.WriteLine($"Playlist : {ApiClient.Playlist.GetCountAsync().Result:N0}");
        Console.WriteLine($"PlaylistTrack : {ApiClient.PlaylistTrack.GetCountAsync().Result:N0}");
        Console.WriteLine($"PlaylistTrackHistory : {ApiClient.PlaylistTrackHistory.GetCountAsync().Result:N0}");
        Console.WriteLine($"Track : {ApiClient.Track.GetCountAsync().Result:N0}");
        
    }
}