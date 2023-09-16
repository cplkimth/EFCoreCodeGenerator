using System.Text;
using System.Text.RegularExpressions;
using EFCoreCodeGeneratorV2.Models;

namespace EFCoreCodeGeneratorV2.Generators;

public static class Generator
{
    public static string Generate(string input, Database database, Table table)
    {
        StringBuilder builder = new (input);

        VariableManager.Instance.Fill(builder);

        PerTable(input, table, builder);
        
        input = builder.ToString();
        builder  = new (input);
        PerDatabase(input, database, builder);

        return builder.ToString();
    }

    private static void PerTable(string input, Table table, StringBuilder builder)
    {
        var matches = Regex.Matches(input, "`(!??)([APFIN]):(.*?):(.*?)``", RegexOptions.Singleline);
        foreach (Match match in matches)
        {
            var criteria = $"{match.Groups[1].Value}{match.Groups[2].Value}";
            var columns = table.Search(criteria);

            List<string> lines = columns.ConvertAll(x => ReplaceColumn(x, match.Groups[4].Value));
            var separator = BuildSeparator(match.Groups[3].Value);
            var replacedText = string.Join(separator, lines);

            builder.Replace(match.Value, replacedText);
        }
    }

    private static void PerDatabase(string input, Database database, StringBuilder builder)
    {
        var matches = Regex.Matches(input, "`T:(.*?):(.*?)``", RegexOptions.Singleline);
        foreach (Match match in matches)
        {
            var tables = database.Tables;
        
            List<string> lines = tables.ConvertAll(x => ReplaceTable(x, match.Groups[2].Value));
            var separator = BuildSeparator(match.Groups[1].Value);
            var replacedText = string.Join(separator, lines);
        
            builder.Replace(match.Value, replacedText);
        }
    }

    private static string BuildSeparator(string template) 
        => template
        .Replace("`N`", Environment.NewLine)
        .Replace("`T`", "\t");

    private static void ReplaceBaseModel(BaseModel baseModel, StringBuilder builder)
    {
        builder.Replace("`Name`", baseModel.Name);
        builder.Replace("`PascalName`", baseModel.PascalName);
        builder.Replace("`CamelName`", baseModel.CamelName);
    }

    private static string ReplaceTable(Table table, string template)
    {
        StringBuilder builder = new(template);
        ReplaceBaseModel(table, builder);

        return builder.ToString();
    }

    private static string ReplaceColumn(Column column, string template)
    {
        StringBuilder builder = new(template);
        ReplaceBaseModel(column, builder);

        builder.Replace("`Type`", column.Type);

        return builder.ToString();
    }
}