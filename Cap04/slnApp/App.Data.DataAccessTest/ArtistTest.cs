using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data.DataAccess;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class ArtistTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();

            var lista = da.GetAll();

            Assert.IsTrue(lista.Count>0);
        }
    }
}
