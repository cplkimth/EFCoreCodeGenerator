#region
using ChinookFW.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace ChinookFW.UnitTest
{
    public partial class TrackDaoTest
    {
        [TestMethod]
        public void GetAsync()
        {
            var tracks = Dao.Track.GetAsync().Result;
            Assert.AreEqual(4, tracks.Count);
        }

        [TestMethod]
        public void Get2Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.AlbumId == 2).Result;
            Assert.AreEqual(3, tracks[0].TrackId);
            Assert.AreEqual(4, tracks[1].TrackId);
            Assert.AreEqual(2, tracks.Count);
        }

        [TestMethod]
        public void Get3Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.Name, true).Result;
            Assert.AreEqual(4, tracks[0].TrackId);
        }

        [TestMethod]
        public void Get4Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.Name, false).Result;
            Assert.AreEqual(2, tracks[0].TrackId);
        }

        [TestMethod]
        public void Get5Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.Name, false, 1, 2).Result;
            Assert.AreEqual(3, tracks[0].TrackId);
            Assert.AreEqual(1, tracks[1].TrackId);
        }

        [TestMethod]
        public void Get6Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.AlbumId == 2, x => x.Name, true).Result;
            Assert.AreEqual(4, tracks[0].TrackId);
            Assert.AreEqual(3, tracks[1].TrackId);
        }

        [TestMethod]
        public void Get7Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.AlbumId == 2, x => x.Name, false).Result;
            Assert.AreEqual(3, tracks[0].TrackId);
            Assert.AreEqual(4, tracks[1].TrackId);
        }

        [TestMethod]
        public void Get8Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.AlbumId == 2, x => x.Name, true, 1, 1).Result;
            Assert.AreEqual(3, tracks[0].TrackId);
            Assert.AreEqual(1, tracks.Count);
        }

        [TestMethod]
        public void Get9Async()
        {
            var tracks = Dao.Track.GetAsync(x => x.AlbumId == 2, x => x.Name, false, 1, 1).Result;
            Assert.AreEqual(4, tracks[0].TrackId);
            Assert.AreEqual(1, tracks.Count);
        }

        
        [TestMethod]
        public void SelectAsync()
        {
            var ids = Dao.Track.SelectAsync(x => x.TrackId).Result;
            Assert.AreEqual(4, ids.Count);
        }

        [TestMethod]
        public void Select2Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.AlbumId == 2, x => x.TrackId).Result;
            Assert.AreEqual(3, ids[0]);
            Assert.AreEqual(4, ids[1]);
            Assert.AreEqual(2, ids.Count);
        }

        [TestMethod]
        public void Select3Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.Name, true, x => x.TrackId).Result;
            Assert.AreEqual(4, ids[0]);
        }

        [TestMethod]
        public void Select4Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.Name, false, x => x.TrackId).Result;
            Assert.AreEqual(2, ids[0]);
        }

        [TestMethod]
        public void Select5Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.Name, false, 1, 2, x => x.TrackId).Result;
            Assert.AreEqual(3, ids[0]);
            Assert.AreEqual(1, ids[1]);
        }

        [TestMethod]
        public void Select6Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.AlbumId == 2, x => x.Name, true, x => x.TrackId).Result;
            Assert.AreEqual(4, ids[0]);
            Assert.AreEqual(3, ids[1]);
        }

        [TestMethod]
        public void Select7Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.AlbumId == 2, x => x.Name, false, x => x.TrackId).Result;
            Assert.AreEqual(3, ids[0]);
            Assert.AreEqual(4, ids[1]);
        }

        [TestMethod]
        public void Select8Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.AlbumId == 2, x => x.Name, true, 1, 1, x => x.TrackId).Result;
            Assert.AreEqual(3, ids[0]);
            Assert.AreEqual(1, ids.Count);
        }

        [TestMethod]
        public void Select9Async()
        {
            var ids = Dao.Track.SelectAsync(x => x.AlbumId == 2, x => x.Name, false, 1, 1, x => x.TrackId).Result;
            Assert.AreEqual(4, ids[0]);
            Assert.AreEqual(1, ids.Count);
        }
    }
}