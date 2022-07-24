using Chinook.Data;

namespace Chinook.DataClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dao.Track.GetCount());

            using var context = DbContextFactory.Create();

            var procedures = new ChinookContextProcedures(context);
            var list = procedures.Album_SearchAsync(1, "for").Result;
            foreach (var x in list)
            {
                Console.WriteLine(x.ArtistId + " / " + x.AlbumId);
            }
        }
    }
}