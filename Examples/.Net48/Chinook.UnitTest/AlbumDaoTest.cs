using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.UnitTest
{
    [TestClass]
    public partial class AlbumDaoTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            var context = DbContextFactory.Create();
            context.Initialize();
        }

        [TestMethod]
        public void GetCount()
        {
            var count = Dao.Album.GetCount();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetByKey()
        {
            var album = Dao.Album.GetByKey(1);
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void ExistsByKey()
        {
            var exist = Dao.Album.ExistsByKey(1);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void Exists()
        {
            var exist = Dao.Album.Exists(x => x.AlbumId == 1);
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void DeleteByKey()
        {
            Dao.Album.DeleteByKey(1);
            Assert.IsFalse(Dao.Album.ExistsByKey(1));
        }

        [TestMethod]
        public void DeleteAll()
        {
            int count = Dao.Album.DeleteAll(x => x.Title.Contains("Those"));
            Assert.AreEqual(1, count);
            Assert.IsFalse(Dao.Album.ExistsByKey(1));
        }

        [TestMethod]
        public void Insert()
        {
            var oldCount = Dao.Album.GetCount();

            var album = new Album();
            album.Title = DateTime.Now.ToString();
            album.ArtistId = 1;
            album = Dao.Album.Insert(album);

            var newCount = Dao.Album.GetCount();

            Assert.AreEqual(oldCount + 1, newCount);
            Assert.IsTrue(album.AlbumId != 0);
        }

        [TestMethod]
        public void InsertMany()
        {
            string title = DateTime.Now.ToString();

            var albums = new List<Album>
                         {
                             new Album {Title = title, ArtistId = 1},
                             new Album {Title = title, ArtistId = 1},
                         };

            var oldCount = Dao.Album.GetCount();
            var insertedCount = Dao.Album.InsertMany(albums);
            var newCount = Dao.Album.GetCount();

            Assert.AreEqual(2, insertedCount);
            Assert.AreEqual(oldCount + 2, newCount);
        }
        
        [TestMethod]
        public void Update()
        {
            var title = DateTime.Now.ToString();

            var album = Dao.Album.GetLast(x => x.AlbumId);
            album.Title = title;
            Dao.Album.Update(album);

            album = Dao.Album.GetLast(x => x.AlbumId);

            Assert.AreEqual(title, album.Title);
        }
        
        [TestMethod]
        public void UpdateMany()
        {
            var albums = Dao.Album.Get();
            foreach (var album in albums)
                album.Title = album.AlbumId.ToString();

            Dao.Album.UpdateMany(albums);

            foreach (var album in albums)
                Assert.AreEqual(album.AlbumId, int.Parse(album.Title));
        }

        [TestMethod]
        public void GetFirst()
        {
            var album = Dao.Album.GetFirst();
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst2()
        {
            var album = Dao.Album.GetFirst(x => x.Title.Contains("Rock"));
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst3()
        {
            var album = Dao.Album.GetFirst(x => x.Title);
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetFirst4()
        {
            var album = Dao.Album.GetFirst(x => x.Title.Contains("Rock"), x => x.Title);
            Assert.AreEqual(1, album.AlbumId);
        }

        [TestMethod]
        public void GetLast()
        {
            var album = Dao.Album.GetLast(x => x.AlbumId);
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void GetLast2()
        {
            var album = Dao.Album.GetLast(x => x.Title.Contains("Rock"));
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void GetLast3()
        {
            var album = Dao.Album.GetLast(x => x.Title.Contains("Rock"), x => x.AlbumId);
            Assert.AreEqual(2, album.AlbumId);
        }

        [TestMethod]
        public void SelectFirst()
        {
            var title = Dao.Album.SelectFirst(x => x.Title);
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst2()
        {
            var title = Dao.Album.SelectFirst(x => x.Title.Contains("Rock"), x => x.Title);
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst3()
        {
            var title = Dao.Album.SelectFirst(x => x.AlbumId, x => x.Title);
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectFirst4()
        {
            var title = Dao.Album.SelectFirst(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title);
            Assert.AreEqual("For Those About To Rock We Salute You", title);
        }

        [TestMethod]
        public void SelectLast()
        {
            var title = Dao.Album.SelectLast(x => x.AlbumId, x => x.Title);
            Assert.AreEqual("Let There Be Rock", title);
        }

        [TestMethod]
        public void SelectLast2()
        {
            var title = Dao.Album.SelectLast(x => x.Title.Contains("Rock"), x => x.Title);
            Assert.AreEqual("Let There Be Rock", title);
        }

        [TestMethod]
        public void SelectLast3()
        {
            var title = Dao.Album.SelectLast(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title);
            Assert.AreEqual("Let There Be Rock", title);
        }
    }
}