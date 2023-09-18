#region
using System;
using System.Collections.Generic;
#endregion

namespace EFCoreCodeGenerator.Utilities
{
    public static class TypeExtension
    {
        private static readonly Dictionary<Type, string> _types = new();

        static TypeExtension()
        {
            _types.Add(typeof(bool), "bool");
            _types.Add(typeof(byte), "byte");
            _types.Add(typeof(char), "char");
            _types.Add(typeof(sbyte), "sbyte");
            _types.Add(typeof(short), "short");
            _types.Add(typeof(int), "int");
            _types.Add(typeof(uint), "uint");
            _types.Add(typeof(long), "long");
            _types.Add(typeof(ulong), "ulong");
            _types.Add(typeof(float), "float");
            _types.Add(typeof(double), "double");
            _types.Add(typeof(decimal), "decimal");
            _types.Add(typeof(DateTime), "DateTime");
            _types.Add(typeof(DateTimeOffset), "DateTimeOffset");
            _types.Add(typeof(TimeSpan), "TimeSpan");
            _types.Add(typeof(Guid), "Guid");
            _types.Add(typeof(bool?), "bool?");
            _types.Add(typeof(byte?), "byte?");
            _types.Add(typeof(char?), "char?");
            _types.Add(typeof(sbyte?), "sbyte?");
            _types.Add(typeof(short?), "short?");
            _types.Add(typeof(int?), "int?");
            _types.Add(typeof(uint?), "uint?");
            _types.Add(typeof(long?), "long?");
            _types.Add(typeof(ulong?), "ulong?");
            _types.Add(typeof(float?), "float?");
            _types.Add(typeof(double?), "double?");
            _types.Add(typeof(decimal?), "decimal?");
            _types.Add(typeof(DateTime?), "DateTime?");
            _types.Add(typeof(DateTimeOffset?), "DateTimeOffset?");
            _types.Add(typeof(TimeSpan?), "TimeSpan?");
            _types.Add(typeof(Guid?), "Guid?");
            _types.Add(typeof(byte[]), "byte[]");
            _types.Add(typeof(string), "string");


            CSharpKeywords = new HashSet<string>
                             {
                                 "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit",
                                 "extern", "false", "finally", "fixed", "float", "for ", "foreach", "goto", "if ", "implicit", "in", "int ", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator",
                                 "out", "override", "params", "protected", "public", "ref", "return", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint",
                                 "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
                             };
        }

        public static string ToClrName(this string typeName)
        {
            if (typeName is "Byte[]")
                return "byte[]";

            var nonNullName = typeName.EndsWith("?") ? typeName[..^1] : typeName;
            
            var name = nonNullName switch
            {
                nameof(Boolean) => "bool",
                nameof(SByte) => "sbyte",
                nameof(Byte) => "byte",
                nameof(Int16) => "short",
                nameof(UInt16) => "ushort",
                nameof(Int32) => "int",
                nameof(UInt32) => "uint",
                nameof(Int64) => "long",
                nameof(UInt64) => "ulong",
                nameof(Single) => "float",
                nameof(Double) => "double",
                nameof(Decimal) => "decimal",
                nameof(String) => "string",
                _ => nonNullName
            };

            if (typeName.EndsWith("?"))
                name += "?";

            return name;
        }

        public static string ToClrName(this Type type)
        {
            if (_types.ContainsKey(type))
                return _types[type];

            throw new NotImplementedException("Extension.ToClrName");
        }

        private static readonly HashSet<string> CSharpKeywords;

        /// <summary>
        /// C#의 키워드면 @를 붙인다.
        /// </summary>
        public static string ToIdentifier(this string name)
        {
            if (CSharpKeywords.Contains(name))
                return "@" + name;
            else
                return name;
        }
    }
}