using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Test
{
    [TestClass]
    public class GenreDATest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new GenreDA();
            var listado = da.GetAll("Rock");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new GenreDA();
            var entity = da.Get(2);

            Assert.IsTrue(entity.GenreId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new GenreDA();
            var genre = new Genre();
            genre.Name = "Bachata";
            int id = da.Insert(genre);

            Assert.IsTrue(id > 0, "El nombre del género ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new GenreDA();
            var genre = new Genre();
            genre.GenreId = 26;
            genre.Name = "Rock n' Pop";
            int registrosAfectados = da.Update(genre);

            Assert.IsTrue(registrosAfectados > 0, "El género ya tiene ese nombre");
        }

        [TestMethod]
        public void Delete()
        {
            var da = new GenreDA();
            var genre = new Genre();
            genre.GenreId = 26;
            int registrosAfectados = da.Delete(genre);

            Assert.IsTrue(registrosAfectados > 0, "No se encontró el ID del género");
        }
    }
}
