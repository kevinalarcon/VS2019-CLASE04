using App.Data.Repository;
using App.Entities.Base;
using App.Service.WCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib
{
    public class MantenimientoServices : IMantenimientoServices
    {
        public bool DeleteAlbum(Album entity)
        {
            throw new NotImplementedException();
        }
        #region Artist
        public bool DeleteArtist(Artist entity)
        {
            bool result = false;

            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Remove(entity);
                uw.Complete();

                result = true;
            }

            return result;
        }

        public bool DeleteCustomer(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenre(Genre entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInvoice(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAlbumAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Album GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            var result = new List<Artist>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetAll(
                    item => item.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public Artist GetArtistById(int id)
        {
            var result = new Artist();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetById(id);
            }
            return result;
        }

        public IEnumerable<Customer> GetCustomerAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeeAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetGenreAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Genre GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetInvoiceAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertAlbum(Album entity)
        {
            throw new NotImplementedException();
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;

            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Add(entity);
                uw.Complete();

                result = entity.ArtistId;
            }

            return result;
        }

        public int InsertCustomer(Customer entity)
        {
            throw new NotImplementedException();
        }

        public int InsertEmployee(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int InsertGenre(Genre entity)
        {
            throw new NotImplementedException();
        }

        public int InsertInvoice(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAlbum(Album entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateArtist(Artist entity)
        {
            bool result = false;

            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Update(entity);
                uw.Complete();

                result = true;
            }

            return result;
        }

        public bool UpdateCustomer(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGenre(Genre entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInvoice(Invoice entity)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
