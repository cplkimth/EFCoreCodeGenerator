#region
using ChinookCore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace ChinookCore.UnitTest
{
    [TestClass]
    public partial class PlaylistTrackDaoTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            ChinookContextProcedures procedures = new ChinookContextProcedures(DbContextFactory.Create());
            // procedures.InitializeAsync().Wait();
        }

        [TestMethod]
        public void Insert()
        {
            PlaylistTrack entity = new PlaylistTrack();
            entity.PlaylistId = 2;
            entity.TrackId = 2;

            Dao.PlaylistTrack.Insert(entity);

            Assert.AreEqual(4, Dao.PlaylistTrack.GetCount());
        }

        [TestMethod]
        public void Delete()
        {
            Dao.PlaylistTrack.DeleteByKey(2, 1);

            Assert.AreEqual(2, Dao.PlaylistTrack.GetCount());
        }
    }
}