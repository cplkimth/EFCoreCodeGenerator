using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChinookCore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChinookCore.UnitTest
{
    [TestClass]
    public partial class ArtistDaoTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            ChinookContextProcedures procedures = new ChinookContextProcedures(new ChinookContext());
            procedures.InitializeAsync().Wait();
        }

        [TestMethod]
        public void InsertOrUpdate()
        {
            string artistName = DateTime.Now.ToString();

            var artist = Dao.Artist.GetByKey(1);
            artist.Name = artistName;
            Dao.Artist.InsertOrUpdate(artist);
            
            artist = Dao.Artist.GetByKey(1);
            Assert.AreEqual(artistName, artist.Name);
        }

        [TestMethod]
        public void InsertOrUpdate2()
        {
            string artistName = DateTime.Now.ToString();

            var artist = Dao.Artist.Create();
            artist.Name = artistName;
            Dao.Artist.InsertOrUpdate(artist);
            
            Assert.AreEqual(2, Dao.Artist.GetCount());
        }

        [TestMethod]
        public void InsertIfNotExist()
        {
            var artist = Dao.Artist.Create();
            artist.Name = DateTime.Now.ToString();
            Dao.Artist.InsertIfNotExist(artist);
            
            Assert.AreEqual(2, Dao.Artist.GetCount());
        }

        [TestMethod]
        public void InsertIfNotExist2()
        {
            var artist = Dao.Artist.GetByKey(1);
            Dao.Artist.InsertIfNotExist(artist);
            
            Assert.AreEqual(1, Dao.Artist.GetCount());
        }
    }
}