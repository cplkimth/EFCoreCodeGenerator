using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using EFCoreCodeGenerator.Exceptions;
using EFCoreCodeGenerator.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeGenerator;

public class VariableManager
{
    #region singleton
    private static readonly Lazy<VariableManager> _instance = new(() => new VariableManager());

    public static VariableManager Instance => _instance.Value;

    private VariableManager()
    {
    }
    #endregion

    private Dictionary<string, string> _variables = new();

    private const string SolutionName = "SolutionName";
    private const string SolutionDirectory = "SolutionDirectory";
    private const string DataProjectName = "DataProjectName";
    private const string DataProjectDirectory = "DataProjectDirectory";
    private const string DataProjectNamespace = "DataProjectNamespace";
    private const string DbContextName = "DbContextName";

    public void Inialize(string templateDirectory, DbContext dbContext)
    {
        var jsonPath = Path.Combine(templateDirectory, "variables.json");

        if (File.Exists(jsonPath) is false)
            throw new FileNotFoundException("variables.json file does NOT exist!");

        var json = File.ReadAllText(jsonPath);
        _variables = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

        if (dbContext != null)
        {
            _variables[DataProjectNamespace] = dbContext.GetType().Namespace;
            _variables[DbContextName] = dbContext.GetType().Name;
        }

        if (_variables.IsEmptyOrDefault(SolutionName))
            _variables[SolutionName] = Utility.GetSolutionRoot().Name;

        if (_variables.IsEmptyOrDefault(SolutionDirectory))
            _variables[SolutionDirectory] = Utility.GetSolutionRoot().FullName;

        if (_variables.IsEmptyOrDefault(DataProjectName))
            _variables[DataProjectName] = "Data";

        if (_variables.IsEmptyOrDefault(DataProjectDirectory))
            _variables[DataProjectDirectory] = Path.Combine(_variables[SolutionDirectory], _variables[SolutionName] + "." + _variables[DataProjectName]);

        if (_variables.IsEmptyOrDefault(DataProjectNamespace))
            _variables[DataProjectNamespace] = _variables[SolutionName] + "." + _variables[DataProjectName];

        if (_variables.IsEmptyOrDefault(DbContextName))
            _variables[DbContextName] = DbContextName;

        #region preset
        _variables["GeneratedTime"] = DateTime.Now.ToString();

        _variables["BeginOnView"] = "/*";
        _variables["BeginOnNoCache"] = "/*";
        _variables["BeginOnVoidReturn"] = "/*";

        _variables["EndOnView"] = "*/";
        _variables["EndOnNoCache"] = "*/";
        _variables["EndOnVoidReturn"] = "*/";
        #endregion
    }

    public string this[string variableName]
    {
        get
        {
            if (_variables.TryGetValue(variableName, out var item))
                return item;

            throw new VariableNotExistException(variableName);
        }
    }

    public string Fill(string input)
    {
        StringBuilder builder = new(input);

        Fill(builder);

        return builder.ToString();
    }

    public void Fill(StringBuilder builder)
    {
        foreach (var key in _variables.Keys)
            builder.Replace($"`{key}`", _variables[key]);
    }
}