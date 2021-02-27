#region
using System;
using EFCoreCodeGenerator.Utilities;
#endregion

namespace EFCoreCodeGenerator.Schema
{
    /// <summary>
    ///     Database, Table, Column  의 부모
    /// </summary>
    [Serializable]
    public abstract class SchemaElement
    {
        protected readonly string _name;

        protected SchemaElement()
        {
        }

        protected SchemaElement(string name)
        {
            _name = name;
        }

        public virtual string Name => _name.ToIdentifier();

        public virtual string PascalName => ToPascalName(_name);

        public virtual string CamelName => ToCamelName(_name).ToIdentifier();

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