#region
using System;
using System.IO;
using System.Text;
using System.Text.Json;
#endregion

namespace EFCoreCodeGenerator.Elements
{
    public class Template
    {
        public int Version { get; set; }

        public TemplateScope Scope { get; set; }

        public string TargetPath { get; set; }

        public bool Overwritable { get; set; }

        public string Body { get; set; }

        private const string Spliter = "*** body starts here ***";

        public void WriteToFile(string path)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(JsonSerializer.Serialize(this));
            builder.AppendLine(Spliter);
            builder.AppendLine(Body);

            File.WriteAllText(path, builder.ToString());
        }

        public static Template Load(string templateText)
        {
            var tokens = templateText.Split(new[] {Spliter}, StringSplitOptions.RemoveEmptyEntries);

            Template template = JsonSerializer.Deserialize<Template>(tokens[0]);
            template.Body = tokens[1];

            return template;
        }
    }

    public enum TemplateScope
    {
        Database,
        Table
    }
}