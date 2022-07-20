using System;
using Chinook.Data;
using EFCoreCodeGenerator.Schema;
using EFCoreCodeGenerator.SchemaExtractors;
using EFCoreCodeGenerator.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreCodeGenerator.UnitTest
{
    [TestClass()]
    public class DbContextSchemaExtractorTests
    {
        private static SchemaExtractor _extractor;
        
        private static Database _database;

        private const string AlbumTable = "Album";
        private const string AlbumPk = "AlbumId";
        private const string AlbumId = "AlbumId";
        private const string ArtistId = "ArtistId";

        private Table Album => _database.Tables.Find(x => x.Name == AlbumTable);
        private Table Track => _database.Tables.Find(x => x.Name == "Track");
        private Table PlaylistTrack => _database.Tables.Find(x => x.Name == "PlaylistTrack");

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _extractor = SchemaExtractor.Instance;
            _database = _extractor.Extract(new ChinookContext());
        }

        [TestMethod()]
        public void 테이블이_존재()
        {
            Assert.AreEqual(AlbumTable, Album.Name);
        }

        [TestMethod()]
        public void PK()
        {
            Assert.AreEqual(AlbumPk, Album.Columns.Find(x => x.PrimaryKey).Name);
        }

        [TestMethod()]
        public void 다중_PK()
        {
            var pks = PlaylistTrack.Columns.FindAll(x => x.PrimaryKey);

            Assert.IsTrue(pks.Exists(x => x.Name == "PlaylistId"));
            Assert.IsTrue(pks.Exists(x => x.Name == "TrackId"));
        }

        [TestMethod()]
        public void Identity()
        {
            Assert.AreEqual(AlbumId, Album.Columns.Find(x => x.Identity).Name);
        }

        [TestMethod()]
        public void FK()
        {
            Assert.AreEqual(ArtistId, Album.Columns.Find(x => x.ForeignKey).Name);
        }

        [TestMethod()]
        public void 다중_FK()
        {
            var fks = PlaylistTrack.Columns.FindAll(x => x.ForeignKey);

            Assert.IsTrue(fks.Exists(x => x.Name == "PlaylistId"));
            Assert.IsTrue(fks.Exists(x => x.Name == "TrackId"));
        }

        [TestMethod()]
        public void BitColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "BitCol");

            Assert.AreEqual(typeof(bool).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void BitColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "BitColNull");

            Assert.AreEqual(typeof(bool?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void TinyIntColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "TinyIntCol");

            Assert.AreEqual(typeof(byte).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void TinyIntColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "TinyIntColNull");

            Assert.AreEqual(typeof(byte?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallIntColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallIntCol");

            Assert.AreEqual(typeof(short).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallIntColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallIntColNull");

            Assert.AreEqual(typeof(short?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void BigIntColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "BigIntCol");

            Assert.AreEqual(typeof(long).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void BigIntColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "BigIntColNull");

            Assert.AreEqual(typeof(long?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void CharColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "CharCol");

            Assert.AreEqual(typeof(string).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void CharColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "CharColNull");

            Assert.AreEqual(typeof(string).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void VarCharColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "VarCharCol");

            Assert.AreEqual(typeof(string).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void VarCharColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "VarCharColNull");

            Assert.AreEqual(typeof(string).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void NcharColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "NcharCol");

            Assert.AreEqual(typeof(String).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void NcharColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "NcharColNull");

            Assert.AreEqual(typeof(String).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void NvarCharColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "NvarCharCol");

            Assert.AreEqual(typeof(String).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void NvarCharColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "NvarCharColNull");

            Assert.AreEqual(typeof(String).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void BinaryColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "BinaryCol");

            Assert.AreEqual(typeof(Byte[]).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void BinaryColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "BinaryColNull");

            Assert.AreEqual(typeof(Byte[]).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DateColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "DateCol");

            Assert.AreEqual(typeof(DateTime).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DateColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "DateColNull");

            Assert.AreEqual(typeof(DateTime?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DateTimeColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "DateTimeCol");

            Assert.AreEqual(typeof(DateTime).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DateTimeColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "DateTimeColNull");

            Assert.AreEqual(typeof(DateTime?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallDateTimeColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallDateTimeCol");

            Assert.AreEqual(typeof(DateTime).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallDateTimeColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallDateTimeColNull");

            Assert.AreEqual(typeof(DateTime?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DecimalColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "DecimalCol");

            Assert.AreEqual(typeof(Decimal).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void DecimalColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "DecimalColNull");

            Assert.AreEqual(typeof(Decimal?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void FloatColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "FloatCol");

            Assert.AreEqual(typeof(Double).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void FloatColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "FloatColNull");

            Assert.AreEqual(typeof(Double?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void RealColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "RealCol");

            Assert.AreEqual(typeof(float).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void RealColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "RealColNull");

            Assert.AreEqual(typeof(float?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallMoneyColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallMoneyCol");

            Assert.AreEqual(typeof(Decimal).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void SmallMoneyColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "SmallMoneyColNull");

            Assert.AreEqual(typeof(Decimal?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void TimeStampColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "TimeStampCol");

            Assert.AreEqual(typeof(Byte[]).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void TimeColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "TimeCol");

            Assert.AreEqual(typeof(TimeSpan).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void TimeColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "TimeColNull");

            Assert.AreEqual(typeof(TimeSpan?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void GuidColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "GuidCol");

            Assert.AreEqual(typeof(Guid).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void GuidColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "GuidColNull");

            Assert.AreEqual(typeof(Guid?).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void VarBinaryColumn()
        {
            var column = Track.Columns.Find(x => x.Name == "VarBinaryCol");

            Assert.AreEqual(typeof(byte[]).ToClrName(), column.Type);
        }

        [TestMethod()]
        public void VarBinaryColumnNull()
        {
            var column = Track.Columns.Find(x => x.Name == "VarBinaryColNull");

            Assert.AreEqual(typeof(byte[]).ToClrName(), column.Type);
        }
    }
}