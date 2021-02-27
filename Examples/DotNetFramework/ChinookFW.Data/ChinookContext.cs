using Microsoft.EntityFrameworkCore;

namespace ChinookFW.Data
{
    public partial class ChinookContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.,3423;Initial Catalog=Chinook;Integrated Security=True");
        }

        public static ChinookContext Create()
        {
            ChinookContext context = new ChinookContext();
            return context;
        }
    }
}