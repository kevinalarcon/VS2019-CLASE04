using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetCount()>0);
        }

        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();
            var listado = da.GetAll("Aero");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistDA();
            var entity = da.Get(2);

            Assert.IsTrue(entity.ArtistId>0);
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new ArtistDA();
            var listado = da.GetAllSP("Aero");

            Assert.IsTrue(listado.Count > 0);
        }
    }
}
