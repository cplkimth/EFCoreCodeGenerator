using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Data;

namespace Chinook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dao.Track.GetCount());
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }
    }
}
