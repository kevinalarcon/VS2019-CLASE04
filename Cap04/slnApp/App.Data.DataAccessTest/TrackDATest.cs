using System;
using System.Linq;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class TrackDATest
    {
        [TestMethod]
        public void ConsultarTracks()
        {
            var da = new TrackDA();
            var listado = da.ConsultarTracks("%VOLTA%");

            Assert.IsTrue(listado.Count() > 0);

        }

        [TestMethod]
        public void ConsultarTracksQ()
        {
            var da = new TrackDA();
            var listado = da.ConsultarTracksQ("%VOLTA%");

            Assert.IsTrue(listado.Count() > 0);

        }
    }
}
