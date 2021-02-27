using Microsoft.EntityFrameworkCore;

namespace ChinookFW.Data
{
    public partial class ChinookContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

                // 연결문자열 설정
                optionsBuilder.UseSqlServer("Data Source=.,3423;Initial Catalog=Chinook;Integrated Security=True");
        
                // 콘솔에 로그 출력
                optionsBuilder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(LoggerType.Console));
        }

        public static ChinookContext Create()
        {
            ChinookContext context = new ChinookContext();
            return context;
        }
    }
}