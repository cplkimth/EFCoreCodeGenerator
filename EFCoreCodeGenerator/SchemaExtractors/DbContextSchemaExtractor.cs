#region usings
using System.Linq;
using EFCoreCodeGenerator.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public class DbContextSchemaExtractor : SchemaExtractor
{
    public DbContextSchemaExtractor(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly DbContext _dbContext;

    public override Database Extract()
    {
        var databaseName = _dbContext.GetType().Name.Replace("Context", string.Empty);

        var database = new Database(databaseName);
        database.DataContext = _dbContext.GetType().Name;

        // 기본키가 없는 타입을 제외. (프로시져의 반환 타입 등)
        var tables = _dbContext.Model.GetEntityTypes().Where(x => x.FindPrimaryKey() != null);

        foreach (var entityType in tables)
        {
            var table = new Table(database, entityType.ClrType.Name);

            foreach (var p in entityType.GetProperties())
            {
                var column = new Column(table, p.Name);
                column.Type = p.ClrType.ToClrName();
                column.PrimaryKey = p.IsPrimaryKey();
                column.ForeignKey = p.IsForeignKey();
                column.Identity = IsIdentityColumn(p);
                column.Nullable = p.IsNullable;
            }
        }

        return database;
    }

    private bool IsIdentityColumn(IProperty property)
    {
        try
        {
            var annotation = property.GetAnnotation("SqlServer:ValueGenerationStrategy");
            return (SqlServerValueGenerationStrategy) annotation.Value == SqlServerValueGenerationStrategy.IdentityColumn;
        }
        catch
        {
            return false;
        }
    }
}