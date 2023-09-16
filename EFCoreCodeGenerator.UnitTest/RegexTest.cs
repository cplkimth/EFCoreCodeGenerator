#region usings
using System;
using System.IO;
using System.Text.RegularExpressions;
using EFCoreCodeGenerator.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace EFCoreCodeGenerator.UnitTest;

[TestClass]
public class RegexTests
{
    private static string _text;

    [ClassInitialize]
    public static void SetUp(TestContext testContext)
    {
        _text = File.ReadAllText(@"D:\git\EFCoreCodeGenerator\Examples\.NetCore\Chinook.Data\templates\Data\Test.jsonmp");
    }

    [TestMethod]
    public void 테이블이_존재하는_경우()
    {
        var matches = Regex.Matches(_text, @"`([APFI]):(.*?):(.*?) \1`", RegexOptions.Singleline);
        Console.WriteLine(matches);
    }

    [TestMethod]
    public void 테이블이_존재하지_않는_경우()
    {
        var matches = Regex.Matches(_text, @"`([T]):(.*?):(.*?) \1`", RegexOptions.Singleline);
        Console.WriteLine(matches);
    }
}