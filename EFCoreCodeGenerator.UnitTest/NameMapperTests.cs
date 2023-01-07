#region usings
using EFCoreCodeGenerator.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace EFCoreCodeGenerator.UnitTest;

[TestClass]
public class NameMapperTests
{
    [ClassInitialize]
    public static void SetUp(TestContext testContext)
    {
        NameMapper.Instance.Register(@"Files\Chinook.yaml");
    }

    [TestMethod]
    public void 테이블이_존재하는_경우()
    {
        Assert.AreEqual("album", NameMapper.Instance["album"]);
    }

    [TestMethod]
    public void 테이블이_존재하지_않는_경우()
    {
        Assert.AreEqual("Artist", NameMapper.Instance["artist"]);
    }

    [TestMethod]
    public void 테이블이_존재하고_컬럼이_존재하는_경우()
    {
        Assert.AreEqual("album_id", NameMapper.Instance["album", "album_id"]);
    }

    [TestMethod]
    public void 테이블이_존재하고_컬럼이_존재하지_않는_경우()
    {
        Assert.AreEqual("Title", NameMapper.Instance["album", "title"]);
    }

    [TestMethod]
    public void 테이블이_존재하지_않고_컬럼이_존재하는_경우()
    {
        Assert.AreEqual("artist_id", NameMapper.Instance["artist", "artist_id"]);
    }

    [TestMethod]
    public void 테이블이_존재하지_않고_컬럼이_존재하지_않는_경우()
    {
        Assert.AreEqual("Name", NameMapper.Instance["artist", "name"]);
    }
}