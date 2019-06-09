using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib.Interfaces
{
    [ServiceContract]
    public interface IMantenimientoServices
    {
        #region Artist
        [OperationContract]
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        int InsertArtist(Artist entity);

        [OperationContract]
        bool UpdateArtist(Artist entity);

        [OperationContract]
        bool DeleteArtist(Artist entity);

        [OperationContract]
        Artist GetArtistById(int id);
        #endregion

        #region Album
        [OperationContract]
        IEnumerable<Album> GetAlbumAll(string nombre);

        [OperationContract]
        int InsertAlbum(Album entity);

        [OperationContract]
        bool UpdateAlbum(Album entity);

        [OperationContract]
        bool DeleteAlbum(Album entity);

        [OperationContract]
        Album GetAlbumById(int id);
        #endregion

        #region Customer
        [OperationContract]
        IEnumerable<Customer> GetCustomerAll(string nombre);

        [OperationContract]
        int InsertCustomer(Customer entity);

        [OperationContract]
        bool UpdateCustomer(Customer entity);

        [OperationContract]
        bool DeleteCustomer(Customer entity);

        [OperationContract]
        Customer GetCustomerById(int id);
        #endregion

        #region Employee
        [OperationContract]
        IEnumerable<Employee> GetEmployeeAll(string nombre);

        [OperationContract]
        int InsertEmployee(Employee entity);

        [OperationContract]
        bool UpdateEmployee(Employee entity);

        [OperationContract]
        bool DeleteEmployee(Employee entity);

        [OperationContract]
        Employee GetEmployeeById(int id);
        #endregion

        #region Genre
        [OperationContract]
        IEnumerable<Genre> GetGenreAll(string nombre);

        [OperationContract]
        int InsertGenre(Genre entity);

        [OperationContract]
        bool UpdateGenre(Genre entity);

        [OperationContract]
        bool DeleteGenre(Genre entity);

        [OperationContract]
        Genre GetGenreById(int id);
        #endregion

        #region Invoice
        [OperationContract]
        IEnumerable<Invoice> GetInvoiceAll(string nombre);

        [OperationContract]
        int InsertInvoice(Invoice entity);

        [OperationContract]
        bool UpdateInvoice(Invoice entity);

        [OperationContract]
        bool DeleteInvoice(Invoice entity);

        [OperationContract]
        Invoice GetInvoiceById(int id);
        #endregion
    }
}
