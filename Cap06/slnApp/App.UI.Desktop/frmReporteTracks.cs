using App.Data.DataAccess;
using App.Data.Repository;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class frmReporteTracks : Form
    {
        public frmReporteTracks()
        {
            InitializeComponent();

            InicializarValores();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        #region "Procedimientos propios"
        private void Buscar()
        {
            var uw = new AppUnitOfWork();

            var listado = uw.TrackRepository.ReporteTrack
                (txtNombre.Text.Trim());

            gvListado.DataSource = listado;
            gvListado.Refresh();

        }

        private void InicializarValores()
        {
            //Obteniendo información de géneros
            var genreDA = new GenreDA();
            var genreListado = genreDA.GetAll().ToList();

            genreListado.Insert(0,new
                Genre()
            {
                GenreId=0,
                Name="Todos"
            });
           

            cboGeneros.DataSource = genreListado;
            cboGeneros.Refresh();

            //Obteniendo información de Media Type
            var mediaTypeDA = new MediaTypeDA();
            var mediaListado = mediaTypeDA.GetAll().ToList();

            mediaListado.Insert(0, new
                MediaType()
            {
                MediaTypeId = 0,
                Name = "Todos"
            });


            cboMediaType.DataSource = mediaListado;
            cboMediaType.Refresh();



        }
        #endregion


    }
}
