#region usings
using System.Collections.Generic;
using System.Linq;
using EFCoreCodeGenerator.Models;
using EFCoreCodeGenerator.Utilities;
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

    public override Table[] Extract()
    {
        List<Table> tables = new();

        // 기본키가 없는 타입을 제외. (프로시져의 반환 타입 등)
        var entityTypes = _dbContext.Model.GetEntityTypes().Where(x => x.FindPrimaryKey() != null);

        foreach (var entityType in entityTypes)
        {
            var table = new Table(entityType.ClrType.Name);
            tables.Add(table);

            foreach (var p in entityType.GetProperties())
            {
                var column = new Column(p.Name, p.ClrType.ToClrName())
                             {
                                 PK = p.IsPrimaryKey(),
                                 FK  = p.IsForeignKey(),
                                 ID = IsIdentityColumn(p),
                                 Null = p.IsNullable
                             };
                table.Columns.Add(column);
            }
        }

        return tables.ToArray();
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