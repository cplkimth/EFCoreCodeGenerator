#region
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
            var container = EdmxHelper.EdmxHelper.Parse(edmxPath)[0];

            var databaseName = container.Name
                .Replace("Entities", string.Empty)
                .Replace("Context", string.Empty);
            Database database = new Database(databaseName);
            database.DataContext = container.Name;

            foreach (var entity in container.Entities)
            {
                Table table = new Table(database, entity.Name);

                foreach (var property in entity.GetProperties())
                {
                    Column column = new Column(table, property.Name);
                    column.Identity = property.Identity;
                    column.PrimaryKey = property.IsKey;
                    column.ForeignKey = property.ForeignKey;
                    column.Type = property.ScalarType.Namespace + "." + property.ScalarType.Name;
                    column.Nullable = property.Nullable;

                    if (property.Nullable && column.Type.IsValueType())
                        column.Type += "?";
                }
            }

            return database;
        }
    }
}