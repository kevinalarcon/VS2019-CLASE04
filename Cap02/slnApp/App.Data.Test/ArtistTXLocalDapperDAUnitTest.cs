using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistTXLocalDapperDAUnitTest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistTXLocalDapperDA();

            Assert.IsTrue(da.GetCount()>0);
        }

        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistTXLocalDapperDA();
            var listado = da.GetAll("%Aero%");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistTXLocalDapperDA();
            var entity = da.Get(2);

            Assert.IsTrue(entity.ArtistId>0);
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new ArtistTXLocalDapperDA();
            var listado = da.GetAllSP("%Aero%");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artist();
            artist.Name = "Peter Parker";
            int id = da.Insert(artist);

            Assert.IsTrue(id > 0,"El nombre del artista ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artist();
            artist.ArtistId = 276;
            artist.Name = "Steven Strange";
            int registrosAfectados = da.Update(artist);

            Assert.IsTrue(registrosAfectados > 0, "El artista ya tiene ese nombre");
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artist();
            artist.ArtistId = 278;
            int registrosAfectados = da.Delete(artist);

            Assert.IsTrue(registrosAfectados > 0, "No se encontró el ID del artista");
        }
    }
}
