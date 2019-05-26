using System;
using App.Entities;
using EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class AlumnoDAEFTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new AlumnoDAEF();
            var listado = da.GetAll();

            Assert.IsTrue(listado.Count > 0);
        }
    }
}
