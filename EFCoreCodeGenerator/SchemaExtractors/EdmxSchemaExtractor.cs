#region
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using EFCoreCodeGenerator.Schema;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors
{
    public class EdmxSchemaExtractor
    {
        #region singleton
        private static EdmxSchemaExtractor _instance;

        public static EdmxSchemaExtractor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EdmxSchemaExtractor();
                return _instance;
            }
        }

        private EdmxSchemaExtractor()
        {
        }
        #endregion

        public Database Extract(string edmxPath)
        {
            var container = new EdmxLoader(edmxPath);
            container.Load();

            var databaseName = container.EntityContainer.Name
                .Replace("Entities", string.Empty)
                .Replace("Context", string.Empty);
            Database database = new Database(databaseName);
            database.DataContext = container.EntityContainer.Name;

            foreach (var entity in container.Entities)
            {
                // View 제거
                if (entity.Name.StartsWith("vw") || entity.Name.EndsWith("View"))
                    continue;

                Table table = new Table(database, entity.Name);

                var keyNames = entity.KeyProperties.Select(x => x.Name).ToHashSet();

                foreach (var property in entity.Properties)
                {
                    Column column = new Column(table, property.Name);
                    column.PrimaryKey = keyNames.Contains(property.Name);
                    column.Type = property.PrimitiveType.ClrEquivalentType.Name;
                    column.Nullable = property.Nullable;
                    column.ForeignKey = false;
                    column.Identity = false; //property.IsStoreGeneratedComputed;

                    if (property.Nullable && property.PrimitiveType.ClrEquivalentType.IsValueType)
                        column.Type += "?";
                }
            }

            return database;
        }
    }
}