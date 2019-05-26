using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class AlumnoDATest
    {
        [TestMethod]
        public void GetAllSP()
        {
            var da = new AlumnoDA();
            var listado = da.GetAllSP();

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new AlumnoDA();
            var alumno = new Alumno();

            alumno.Nombres = "Kevin Axhel";
            alumno.Apellidos = "Alarcon Quispe";
            alumno.Direccion = "Av. Villaverde 387";
            alumno.Sexo = "M";
            alumno.FechaNacimiento = new DateTime(1993, 6, 25);

            int id = da.Insert(alumno);

            Assert.IsTrue(id > 0,"No se pudo ingresar el alumno");
        }
    }
}
