using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class AlbumDATest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new AlbumDA();
            var listado = da.GetAll("Big Ones");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new AlbumDA();
            var entity = da.Get(2);

            Assert.IsTrue(entity.AlbumId>0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new AlbumDA();
            var album = new Album();
            album.Title = "Kevin-2";
            album.ArtistId = 2;
            int id = da.Insert(album);

            Assert.IsTrue(id > 0,"El nombre del album ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new AlbumDA();
            var album = new Album();
            album.ArtistId = 280;
            album.Title = "Tony Stark";
            album.AlbumId = 20;
            int registrosAfectados = da.Update(album);

            Assert.IsTrue(registrosAfectados > 0, "El album ya tiene ese nombre");
        }

        [TestMethod]
        public void Delete()
        {
            var da = new AlbumDA();
            var album = new Album();
            album.AlbumId = 277;
            int registrosAfectados = da.Delete(album);

            Assert.IsTrue(registrosAfectados > 0, "No se encontró el ID del album");
        }
    }
}
