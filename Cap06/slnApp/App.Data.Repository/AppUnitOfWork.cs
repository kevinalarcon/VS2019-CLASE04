﻿using App.Data.Repository.Interface;
using App.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new DBModel();

            this.ArtistRepository = new ArtistRepository(_context);
            this.AlbumRepository = new AlbumRepository(_context);
        }

        public IArtistRepository ArtistRepository { get; set; }
        public IAlbumRepository AlbumRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}