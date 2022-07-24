using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.UnitTest
{
    public partial class AlbumDaoTest
    {
        #region search
        [TestMethod]
        public void SearchWithArtistName()
        {
            var albums = Dao.Album.Search("AC/DC", null);

            Assert.AreEqual(2, albums.Count);
        }

        [TestMethod]
        public void SearchWithTrackName()
        {
            var albums = Dao.Album.Search(null, "You");

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void SearchWithArtistNameAndTrackName()
        {
            var albums = Dao.Album.Search("AC/DC", "You");

            Assert.AreEqual(1, albums.Count);
        }
        #endregion

        #region procedures
        [TestMethod]
        public void Album_Search()
        {
            var context = DbContextFactory.Create();
            var result = context.Album_Search(1, "For").ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].AlbumId);
        }
        #endregion
    }
}