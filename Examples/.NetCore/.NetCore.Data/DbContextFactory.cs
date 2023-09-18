
#region
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
#endregion

namespace Chinook.Data;

public class DbContextFactory
{
    public static string ConnectionString => ""; // TODO : Type ConnectionString here

    private static PooledDbContextFactory<ChinookContext>? _factory;

    public static ChinookContext Create()
    {
        if (_factory == null)
            InitializeFactory();

        return _factory!.CreateDbContext();
    }

    private static void InitializeFactory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();

        // 콘솔에 로그 출력
#if DEBUG
        optionsBuilder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(
            nameof(LogPath.Console),
            nameof(LogPath.Debug),
            @"ChinookContext.log"));
#endif

        // 엔터티 상태를 트랙킹하지 않음
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        // QuerySplittingBehavior
        var querySplittingBehavior = QuerySplittingBehavior.SplitQuery;

        var options = optionsBuilder
            .UseSqlServer(
                ConnectionString,
                x => x.UseQuerySplittingBehavior(querySplittingBehavior))
            .Options;

        _factory = new PooledDbContextFactory<ChinookContext>(options);
    }
}