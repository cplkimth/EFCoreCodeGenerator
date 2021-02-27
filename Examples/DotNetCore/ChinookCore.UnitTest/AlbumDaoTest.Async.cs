using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChinookCore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChinookCore.UnitTest
{
    public partial class AlbumDaoTest
    {
        [TestMethod]
        public void GetCountAsync()
        {
            var count = Dao.Album.GetCountAsync().Result;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetByArtistIdAsync()
        {
            var albums = Dao.Album.GetByArtistIdAsync(1).Result;
            Assert.AreEqual(2, albums.Count);
        }

        [TestMethod]
        public void GetByKeyAsync()
        {
            var album = Dao.Album.GetByKeyAsync(1).Result;
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void ExistsByKeyAsync()
        {
            var exist = Dao.Album.ExistsByKeyAsync(1).Result;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void ExistsAsync()
        {
            var exist = Dao.Album.ExistsAsync(x => x.AlbumId == 1).Result;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void DeleteByKeyAsync()
        {
            Dao.Album.DeleteByKey(1);
            Assert.IsFalse(Dao.Album.ExistsByKeyAsync(1).Result);
        }

        [TestMethod]
        public void DeleteAllAsync()
        {
            int count = Dao.Album.DeleteAllAsync(x => x.Title.Contains("Those")).Result;
            Assert.AreEqual(1, count);
            Assert.IsFalse(Dao.Album.ExistsByKey(1));
        }

        [TestMethod]
        public void InsertAsync()
        {
            var oldCount = Dao.Album.GetCount();

            var album = new Album();
            album.Title = DateTime.Now.ToString();
            album.ArtistId = 1;
            album = Dao.Album.InsertAsync(album).Result;

            var newCount = Dao.Album.GetCount();

            Assert.AreEqual(oldCount + 1, newCount);
            Assert.IsTrue(album.AlbumId != 0);
        }
        
        [TestMethod]
        public void InsertManyAsync()
        {
            string title = DateTime.Now.ToString();

            var albums = new List<Album>
                         {
                             new Album {Title = title, ArtistId = 1},
                             new Album {Title = title, ArtistId = 1},
                         };

            var oldCount = Dao.Album.GetCount();
            var insertedCount = Dao.Album.InsertManyAsync(albums).Result;
            var newCount = Dao.Album.GetCount();

            Assert.AreEqual(2, insertedCount);
            Assert.AreEqual(oldCount + 2, newCount);
        }

        [TestMethod]
        public void UpdateAsync()
        {
            var title = DateTime.Now.ToString();

            var album = Dao.Album.GetLast(x => x.AlbumId);
            album.Title = title;
            Dao.Album.UpdateAsync(album).Wait();

            album = Dao.Album.GetLast(x => x.AlbumId);

            Assert.AreEqual(title, album.Title);
        }

        [TestMethod]
        public void UpdateManyAsync()
        {
            var albums = Dao.Album.Get();
            foreach (var album in albums)
                album.Title = album.AlbumId.ToString();

            Dao.Album.UpdateManyAsync(albums).Wait();

            foreach (var album in albums)
                Assert.AreEqual(album.AlbumId, int.Parse(album.Title));
        }

        [TestMethod]
        public void GetFirstAsync()
        {
            var album = Dao.Album.GetFirstAsync().Result;
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst2Async()
        {
            var album = Dao.Album.GetFirstAsync(x => x.Title.Contains("Rock")).Result;
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst3Async()
        {
            var album = Dao.Album.GetFirstAsync(x => x.Title).Result;
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst4Async()
        {
            var album = Dao.Album.GetFirstAsync(x => x.Title.Contains("Rock"), x => x.Title).Result;
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetLastAsync()
        {
            var album = Dao.Album.GetLastAsync(x => x.AlbumId).Result;
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void GetLast2Async()
        {
            var album = Dao.Album.GetLastAsync(x => x.Title.Contains("Rock")).Result;
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void GetLast3Async()
        {
            var album = Dao.Album.GetLastAsync(x => x.Title.Contains("Rock"), x => x.AlbumId).Result;
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void SelectFirstAsync()
        {
            var title = Dao.Album.SelectFirstAsync(x => x.Title).Result;
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst2Async()
        {
            var title = Dao.Album.SelectFirstAsync(x => x.Title.Contains("Rock"), x => x.Title).Result;
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst3Async()
        {
            var title = Dao.Album.SelectFirstAsync(x => x.AlbumId, x => x.Title).Result;
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst4Async()
        {
            var title = Dao.Album.SelectFirstAsync(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title).Result;
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectLastAsync()
        {
            var title = Dao.Album.SelectLastAsync(x => x.AlbumId, x => x.Title).Result;
            Assert.AreEqual("Let There Be Rock", title);
        }

        [TestMethod]
        public void SelectLast2Async()
        {
            var title = Dao.Album.SelectLastAsync(x => x.Title.Contains("Rock"), x => x.Title).Result;
            Assert.AreEqual("Let There Be Rock", title);
        }

        [TestMethod]
        public void SelectLast3Async()
        {
            var title = Dao.Album.SelectLastAsync(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title).Result;
            Assert.AreEqual("Let There Be Rock", title);
        }
    }
}