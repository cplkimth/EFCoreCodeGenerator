namespace Chinook.Data;

public partial class Dao
{
    public ChinookContextProcedures Procedures => new(DbContextFactory.Create());
}