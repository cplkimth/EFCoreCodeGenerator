using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EFCoreCodeGenerator.Utilities
{
    public class NameMapper
    {
        #region singleton
        private static NameMapper _instance;

        public static NameMapper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NameMapper();
                return _instance;
            }
        }

        private NameMapper()
        {
        }
        #endregion

        private readonly Dictionary<string, string> _tables = new Dictionary<string, string>();

        private readonly Dictionary<string, Dictionary<string, string>> _columns = new Dictionary<string, Dictionary<string, string>>();

        public void Register(string nameMapperFilePath)
        {
            _tables.Clear();
            _columns.Clear();

            string[] lines = null;
            if (nameMapperFilePath == null)
                lines = new string[0];
            else
                lines = File.ReadAllLines(nameMapperFilePath);

            string currentTable = null;
            foreach (var line in lines)
            {
                var tokens = line.Split(':').Select(x => x.Trim()).ToList();
                var source = tokens[0];
                var target = tokens[1].Length == 0 ? source : tokens[1];

                if (line.TrimStart() == line) // table
                {
                    currentTable = source;

                    _tables.Add(source, target);
                    _columns.Add(source, new Dictionary<string, string>());
                }
                else // column
                {
                    _columns[currentTable].Add(source, target);
                }
            }
        }

        public string this[string table] => _tables[table.Trim()];

        public string this[string table, string column] => _columns[table.Trim()][column.Trim()];
    }
}