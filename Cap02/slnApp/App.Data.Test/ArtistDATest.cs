﻿using System;
using App.Entities;
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

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var artist = new Artist();
            artist.Name = "Kevin-2";
            int id = da.Insert(artist);

            Assert.IsTrue(id > 0,"El nombre del artista ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new ArtistDA();
            var artist = new Artist();
            artist.ArtistId = 280;
            artist.Name = "Tony Stark";
            int registrosAfectados = da.Update(artist);

            Assert.IsTrue(registrosAfectados > 0, "El artista ya tiene ese nombre");
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistDA();
            var artist = new Artist();
            artist.ArtistId = 277;
            int registrosAfectados = da.Delete(artist);

            Assert.IsTrue(registrosAfectados > 0, "No se encontró el ID del artista");
        }
    }
}
