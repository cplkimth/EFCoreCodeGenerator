using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChinookFW.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChinookFW.UnitTest
{
    public partial class ArtistDaoTest
    {
        [TestMethod]
        public void InsertOrUpdateAsync()
        {
            string artistName = DateTime.Now.ToString();

            var artist = Dao.Artist.GetByKey(1);
            artist.Name = artistName;
            Dao.Artist.InsertOrUpdateAsync(artist).Wait();
            
            artist = Dao.Artist.GetByKey(1);
            Assert.AreEqual(artistName, artist.Name);
        }

        [TestMethod]
        public void InsertOrUpdate2Async()
        {
            string artistName = DateTime.Now.ToString();

            var artist = Dao.Artist.Create();
            artist.Name = artistName;
            Dao.Artist.InsertOrUpdateAsync(artist).Wait();
            
            Assert.AreEqual(2, Dao.Artist.GetCount());
        }

        [TestMethod]
        public void InsertIfNotExistAsync()
        {
            var artist = Dao.Artist.Create();
            artist.Name = DateTime.Now.ToString();
            Dao.Artist.InsertIfNotExistAsync(artist).Wait();
            
            Assert.AreEqual(2, Dao.Artist.GetCount());
        }

        [TestMethod]
        public void InsertIfNotExist2Async()
        {
            var artist = Dao.Artist.GetByKey(1);
            Dao.Artist.InsertIfNotExistAsync(artist).Wait();
            
            Assert.AreEqual(1, Dao.Artist.GetCount());
        }
    }
}