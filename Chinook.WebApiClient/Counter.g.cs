
namespace Chinook.WebApiClient;

public class Counter
{
    public static void Print()
    {
                Console.WriteLine($"Album : {ApiClient.Album.GetCountAsync().Result:N0}");
        Console.WriteLine($"Artist : {ApiClient.Artist.GetCountAsync().Result:N0}");
        Console.WriteLine($"Code : {ApiClient.Code.GetCountAsync().Result:N0}");
        Console.WriteLine($"CodeCategory : {ApiClient.CodeCategory.GetCountAsync().Result:N0}");
        Console.WriteLine($"Customer : {ApiClient.Customer.GetCountAsync().Result:N0}");
        Console.WriteLine($"Employee : {ApiClient.Employee.GetCountAsync().Result:N0}");
        Console.WriteLine($"Invoice : {ApiClient.Invoice.GetCountAsync().Result:N0}");
        Console.WriteLine($"InvoiceLine : {ApiClient.InvoiceLine.GetCountAsync().Result:N0}");
        Console.WriteLine($"Playlist : {ApiClient.Playlist.GetCountAsync().Result:N0}");
        Console.WriteLine($"PlaylistTrack : {ApiClient.PlaylistTrack.GetCountAsync().Result:N0}");
        Console.WriteLine($"Track : {ApiClient.Track.GetCountAsync().Result:N0}");
        
    }
}