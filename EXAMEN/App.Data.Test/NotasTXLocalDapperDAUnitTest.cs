using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class NotasTXLocalDapperDAUnitTest
    {
        [TestMethod]
        public void InsertTX()
        {
            var da = new NotasTXLocalDapperDA();
            var notas = new Notas();
            notas.AlumnoID = 1;
            notas.CursoID = 2;
            notas.Nota = 20;
            int id = da.InsertTX(notas);

            Assert.IsTrue(id > 0, "No se pudo ingresar la nota");
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new NotasTXLocalDapperDA();
            var listado = da.GetAllSP(1,1);

            Assert.IsTrue(listado.Count > 0);
        }

    }
}
