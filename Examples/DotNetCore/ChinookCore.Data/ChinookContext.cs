using Microsoft.EntityFrameworkCore;

namespace ChinookCore.Data
{
    public partial class ChinookContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.,3423;Initial Catalog=Chinook;Integrated Security=True");
            }
        }

        // TODO: ChinookContext.Create 사용하도록 템플릿 수정
        // TODO: ChinookContext.Create 시 로거 부착
        public static ChinookContext Create()
        {
            ChinookContext context = new ChinookContext();
            return context;
        }
    }
}