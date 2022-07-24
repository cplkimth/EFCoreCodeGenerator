#region
using System.Linq;
using EFCoreCodeGenerator.Schema;
using EFCoreCodeGenerator.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors
{
    public class DbContextSchemaExtractor
    {
        #region singleton
        private static DbContextSchemaExtractor _instance;

        public static DbContextSchemaExtractor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DbContextSchemaExtractor();
                return _instance;
            }
        }

        private DbContextSchemaExtractor()
        {
        }
        #endregion

        public Database Extract(DbContext dbContext)
        {
            var databaseName = dbContext.GetType().Name.Replace("Context", string.Empty);

            var database = new Database(databaseName);
            database.DataContext = dbContext.GetType().Name;

            // 기본키가 없는 타입을 제외. (프로시져의 반환 타입 등)
            var tables = dbContext.Model.GetEntityTypes().Where(x => x.FindPrimaryKey() != null);

            foreach (var entityType in tables)
            {
                var table = new Table(database, entityType.ClrType.Name);

                foreach (IProperty p in entityType.GetProperties())
                {
                    var column = new Column(table, p.Name);
                    column.Type = p.ClrType.ToClrName();
                    column.PrimaryKey = p.IsPrimaryKey();
                    column.ForeignKey = p.IsForeignKey();
                    column.Identity = p.ValueGenerated == ValueGenerated.OnAdd;
                    column.Nullable = p.IsNullable;
                }
            }

            return database;
        }
    }
}