#region
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using EFCoreCodeGenerator.Schema;
#endregion

namespace EFCoreCodeGenerator.SchemaExtractors;

public class EdmxSchemaExtractor : SchemaExtractor
{
    public EdmxSchemaExtractor(string edmxPath)
    {
        _edmxPath = edmxPath;
    }

    private Dictionary<string, HashSet<string>> _keySets;

    private readonly string _edmxPath;

    public override Database Extract()
    {
        var container = new EdmxLoader(_edmxPath);
        container.Load();

        var databaseName = container.EntityContainer.Name
            .Replace("Entities", string.Empty)
            .Replace("Context", string.Empty);
        Database database = new Database(databaseName);
        database.DataContext = container.EntityContainer.Name;

        LoadKeySets(container.Entities);

        foreach (var entity in container.Entities)
        {
            // View 제거
            if (entity.Name.StartsWith("vw") || entity.Name.EndsWith("View"))
                continue;

            Table table = new Table(database, entity.Name);

            foreach (var property in entity.Properties)
            {
                Column column = new Column(table, property.Name);
                column.PrimaryKey = _keySets[entity.Name].Contains(property.Name);
                column.Type = property.PrimitiveType.ClrEquivalentType.Name;
                column.Nullable = property.Nullable;
                column.ForeignKey = IsForeignKey(entity, property.Name);
                column.Identity = property.StoreGeneratedPattern == StoreGeneratedPattern.Identity;

                if (property.Nullable && property.PrimitiveType.ClrEquivalentType.IsValueType)
                    column.Type += "?";
            }
        }

        return database;
    }

    private bool IsForeignKey(EntityType entity, string propertyName)
    {
        if (entity.DeclaredNavigationProperties.Count == 0)
            return false;

        return entity.DeclaredNavigationProperties.Any(x => _keySets.ContainsKey(x.Name) && _keySets[x.Name].Contains(propertyName));
    }

    private void LoadKeySets(List<EntityType> tables)
    {
        _keySets = new();
        foreach (var table in tables)
        {
            _keySets.Add(table.Name, new HashSet<string>());
            foreach (var key in table.KeyProperties)
                _keySets[table.Name].Add(key.Name);
        }
    }
}