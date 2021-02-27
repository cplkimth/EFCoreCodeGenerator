using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookFW.Data;

namespace ChinookFW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dao.Artist.GetCount());
        }
    }
}
