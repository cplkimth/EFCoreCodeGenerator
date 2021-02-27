using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using EFCoreCodeGenerator.Elements;
using EFCoreCodeGenerator.Schema;

namespace EFCoreCodeGenerator.Generators
{
    internal abstract class DataGenerator : Generator
    {
        protected DataGenerator(Package package) : base(package)
        {
        }

        private const string Directives = "DTACOV-";

        private static readonly string RegularExpression = string.Format(@"<#([{0}]).*?\1#>", Directives);

        public static string Build(Package package, Database database, Table table, Column column, string templateBody)
        {
            Regex regex = new Regex(RegularExpression, RegexOptions.Singleline);
            MatchCollection matches = regex.Matches(templateBody);
            string[] splitedTexts = regex.Split(templateBody);
            splitedTexts = RemoveDirectives(splitedTexts);

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < splitedTexts.Length; i++)
            {
                buffer.Append(splitedTexts[i]);

                if (i < splitedTexts.Length - 1)
                {
                    Generator generator;
                    switch (char.ToUpper(matches[i].Value[2]))
                    {
                        case 'D':
                            generator = new DatabaseGenerator(package, database);
                            break;
                        case 'T':
                            generator = new TableGenerator(package, table);
                            break;
                        case 'A':
                            generator = new TableLoopGenerator(package, database);
                            break;
                        case 'C':
                            generator = new ColumnGenerator(package, column);
                            break;
                        case 'O':
                            generator = new ColumnLoopGenerator(package, table);
                            break;
                        case 'V':
                            generator = new VariableGenerator(package);
                            break;
                        case '-':
                            generator = new CommentGenerator(package);
                            break;
                        default:
                            throw new UnsupportedMacroException(char.ToUpper(matches[i].Value[2]));
                    }

                    Macro macro = ExtractMacro(matches[i].Value);
                    string code = generator.Generate(macro, matches[i].Value);
                    buffer.Append(code);
                }
            }

            return buffer.ToString();
        }

        #region private methods
        private static Macro ExtractMacro(string text)
        {
            Macro macro = new Macro();

            macro.Value = text.Substring(3, text.Length - 6).Trim();

            // loop 인 경우 LoopType과 Seperator를 읽는다.
            if (text[2] == 'A' || text[2] == 'O')
            {
                string[] tokens = macro.Value.Split(new[] {':'}, 3);

                if (tokens[0].Length != 0)
                {
                    macro.LoopType = (LoopType) Enum.Parse(typeof(LoopType), tokens[0]);
                }

                macro.Seperator = tokens[1].Replace("[N]", Environment.NewLine).Replace("[T]", "\t");
                macro.Value = tokens[2];

                // 구분자 다음의 첫 개행문자열은 무시한다.
                if (macro.Value.StartsWith(Environment.NewLine))
                {
                    macro.Value = macro.Value.Substring(2); // "\r\n"
                }
            }

            return macro;
        }

        /// <summary>
        /// TACONG- 와 같은 지시어구로만 이루어진 토큰을 삭제한다.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static string[] RemoveDirectives(string[] tokens)
        {
            List<string> result = new List<string>();

            foreach (string token in tokens)
                if (token.Length != 1 || Directives.Contains(token) == false)
                    result.Add(token);

            return result.ToArray();
        }
        #endregion
    }
}