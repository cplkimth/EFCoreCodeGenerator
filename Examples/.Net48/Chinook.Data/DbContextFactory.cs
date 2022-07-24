
#region
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
#endregion

namespace Chinook.Data
{
    public static partial class DbContextFactory
    {
        static DbContextFactory()
        {
            RawConnectionString = "Data Source=.,3433;Initial Catalog=Chinook;Integrated Security=True";
        }

        public static string RawConnectionString { get; }

        static partial void GetConnectionStringCore(ref string connectionString)
        {
            connectionString = "metadata=res://*/Chinook.csdl|res://*/Chinook.ssdl|res://*/Chinook.msl;provider=System.Data.SqlClient;provider connection string=\"" + RawConnectionString + ";App=EntityFramework\"";
        }

        static partial void CreateCore(ChinookEntities context)
        {
            context.Database.Log = x => Debug.WriteLine(x);
        }
    }
}