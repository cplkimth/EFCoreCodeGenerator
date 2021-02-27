#region
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using EFCoreCodeGenerator.Exceptions;
#endregion

namespace EFCoreCodeGenerator.Elements
{
    public class Package
    {
        public List<Variable> Variables { get; } = new List<Variable>();

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

                Variable variable = Variables.Find(x => x.Name == variableName);

                if (variable == null)
                    throw new VariableNotExistException(variableName);

                return variable.Value;
            }
        }
    }
}