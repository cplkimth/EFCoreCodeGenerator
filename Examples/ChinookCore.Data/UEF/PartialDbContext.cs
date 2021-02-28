
using Microsoft.EntityFrameworkCore;

namespace ChinookCore.Data
{
    public partial class ChinookContext
    {
        public static ChinookContext Create()
        {
            DbContextOptionsBuilder<ChinookContext> builder = new DbContextOptionsBuilder<ChinookContext>();
            
            // 콘솔에 로그 출력
            builder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(LoggerType.Console));

            // 엔터티 상태를 트랙킹하지 않음
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new ChinookContext(builder.Options);
        }
    }
}
