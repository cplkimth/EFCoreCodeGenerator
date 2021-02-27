#region
using System;
using ChinookCore.Data;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Chinook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dao.Artist.GetCount());
        }
    }
}