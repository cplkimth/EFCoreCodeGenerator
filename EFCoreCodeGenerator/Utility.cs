using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace EFCoreCodeGenerator.Schema
{
    public static class Utility
    {
        public static bool IsValueType(this string typeString)
        {
            if (typeString == "System.Data.Linq.Binary")
                return false;

            if (typeString == "System.Xml.Linq.XElement")
                return false;

            var type = Type.GetType(typeString);
            if (type == null)
                return false;

            return type.IsValueType;
        }

        public static void AddRange<T>(this List<T> list, IEnumerable items)
        {
            foreach (T item in items)
                list.Add(item);
        }

        public static List<T> AsList<T>(this IEnumerable items)
        {
            var list = new List<T>();
            foreach (T item in items)
                list.Add(item);

            return list;
        }

        public static string GetExecutableDirectory(string parent)
        {
            var names = new[] {"debug", "release"};
            foreach (var name in names)
            {
                var directory = Directory.EnumerateDirectories(parent, name, SearchOption.AllDirectories).FirstOrDefault();

                if (directory != null)
                    return directory;
            }

            throw new DirectoryNotFoundException($"{parent} ??ο??? release ??? debug ?????? ???????.");
        }

        public static string GetDatabaseName(string contextName)
        {
            return contextName.Replace("Context", "").Replace("Entities", "");
        }

        public static OSPlatform GetOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OSPlatform.Windows;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OSPlatform.OSX;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OSPlatform.Linux;
            else
                throw new Exception("지원되지 않는 OS 입니다.");
        }

        public static string PathSeparator
        {
            get
            {
                if (GetOS() == OSPlatform.Windows)
                    return "\\";
                else
                    return "/";
            }
        }
    }
}