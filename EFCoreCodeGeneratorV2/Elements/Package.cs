#region usings
using System.Text.Json.Serialization;
using EFCoreCodeGenerator.Exceptions;
#endregion

namespace EFCoreCodeGenerator.Elements;

public class Package
{
    public Dictionary<string, string> Variables { get; set; } = new();

    [JsonIgnore]
    public string this[string variableName]
    {
        get
        {
            switch (variableName)
            {
                case "GeneratedTime":
                    return DateTime.Now.ToString();

                case "BeginOnView":
                case "BeginOnNoCache":
                case "BeginOnVoidReturn":
                    return "/*";

                case "EndOnView":
                case "EndOnNoCache":
                case "EndOnVoidReturn":
                    return "*/";
            }

            if (Variables.ContainsKey(variableName))
                return Variables[variableName];

            throw new VariableNotExistException(variableName);
        }
    }
}