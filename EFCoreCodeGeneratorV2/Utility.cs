namespace EFCoreCodeGeneratorV2;

public static class Utility
{
    public static DirectoryInfo GetSolutionRoot(string currentPath = null)
    {
        var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("*.sln").Any())
            directory = directory.Parent;
        
        return directory;
    }

    public static bool IsEmptyOrDefault(this Dictionary<string, string> dictionary, string key)
    {
        if (dictionary.ContainsKey(key) == false) 
            return true;

        if (string.IsNullOrEmpty(dictionary[key]))
            return true;

        return false;
    }
}