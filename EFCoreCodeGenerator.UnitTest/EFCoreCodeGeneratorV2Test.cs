#region usings
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EFCoreCodeGeneratorV2.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace EFCoreCodeGenerator.UnitTest;

[TestClass]
public class EFCoreCodeGeneratorV2
{
    private static Database _package;

    private static string _json;

    [ClassInitialize]
    public static void SetUp(TestContext testContext)
    {
        // _package = new Package {Name = "Chinook"};
        _package = new Database("Chinook");

        var alblum = new Table("Album");
        alblum.Add(
            new Column("AlbumId", "int"){PK = true, ID = true},
            new Column("Title", "string"),
            new Column("ArtistId1", "int"){FK = true}
        );
        _package.Tables.Add(alblum);

        var tradck = new Table ("Track");
        tradck.Add(
            new Column("TrackId", "int"){PK = true, ID = true},
            new Column("Name", "string"),
            new Column("AlbumId", "int"){FK = true},
            new Column("GuidColNull", "Guid?"){Null = true}
        );
        _package.Tables.Add(tradck);

        var playlistTrack = new Table ("PlaylistTrack");
        playlistTrack.Add(
            new Column("PlaylistId", "int"){PK = true, FK = true},
            new Column("TrackId", "int"){PK = true, FK = true},
            new Column("Memo", "string")
        );
        _package.Tables.Add(playlistTrack);

        JsonSerializerOptions options = new()
                                        {
                                            ReferenceHandler = ReferenceHandler.Preserve,
                                            WriteIndented = true
                                        };

        _json = JsonSerializer.Serialize(_package, options);
        _package = JsonSerializer.Deserialize<Database>(_json, options);
    }

    [TestMethod]
    public void Package()
    {
        _package.Name.Should().Be("Chinook");
    }

    [TestMethod]
    public void Entity()
    {
        _package.Tables[0].Name.Should().Be("Album");
    }

    [TestMethod]
    public void Column_PK()
    {
        _package.Tables[0].Columns[0].Name.Should().Be("AlbumId");
        _package.Tables[0].Columns[0].Type.Should().Be("int");
        _package.Tables[0].Columns[0].PK.Should().Be(true);
        _package.Tables[0].Columns[0].ID.Should().Be(true);
    }

    [TestMethod]
    public void Column_FK()
    {
        _package.Tables[1].Columns[3].Name.Should().Be("GuidColNull");
        _package.Tables[1].Columns[3].Type.Should().Be("Guid?");
        _package.Tables[1].Columns[3].Null.Should().Be(true);
    }

    [TestMethod]
    public void Column_DoublePK()
    {
        _package.Tables[2].Columns[0].PK.Should().Be(true);
        _package.Tables[2].Columns[1].PK.Should().Be(true);
    }

    [TestMethod]
    public void Column_DoubleFK()
    {
        _package.Tables[2].Columns[0].FK.Should().Be(true);
        _package.Tables[2].Columns[1].FK.Should().Be(true);
    }

    [TestMethod]
    public void Parent()
    {
        _package.Tables[0].Columns[0].Table.Name.Should().Be(_package.Tables[0].Name);
    }
}