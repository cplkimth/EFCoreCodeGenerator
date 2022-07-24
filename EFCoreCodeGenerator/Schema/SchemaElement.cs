#region
using System;
using System.Text.Json.Serialization;
#endregion

namespace EFCoreCodeGenerator.Schema
{
    /// <summary>
    ///     Database, Table, Column  의 부모
    /// </summary>
    [Serializable]
    public abstract class SchemaElement
    {
        protected SchemaElement()
        {
        }

        protected SchemaElement(string name)
        {
            Name = name.ToIdentifier();
        }

        public string Name { get; set; }

        [JsonIgnore]
        public string PascalName => ToPascalName(Name);

        [JsonIgnore]
        public string CamelName => ToCamelName(Name).ToIdentifier();

        public override string ToString()
        {
            return Name;
        }

        protected static string ToPascalName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        protected static string ToCamelName(string name)
        {
            return char.ToLower(name[0]) + name.Substring(1);
        }
    }
}