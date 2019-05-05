using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class AlbumDA:BaseConnection
    {
        public Album Get(int id)
        {
            var result = new Album();
            var sql = "SELECT * FROM Album where AlbumId = @paramID";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();

                /*Configurando los parametros*/
                cmd.Parameters.Add(
                    new SqlParameter("@paramID", id)
                    );

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    indice = reader.GetOrdinal("AlbumId");
                    result.AlbumId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Ttile");
                    result.Title = reader.GetString(indice);

                    indice = reader.GetOrdinal("ArtistId");
                    result.ArtistId = reader.GetInt32(indice);
                }

            }

            return result;
        }

        public List<Album> GetAll(string filterByName = "")
        {
            var result = new List<Album>();
            var sql = "SELECT * FROM Album WHERE Title LIKE @paramFilterByName";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();

                //Agregar el % para el parametro
                filterByName = $"%{filterByName}%";

                cmd.Parameters.Add(
                    new SqlParameter("@paramFilterByName", filterByName)
                    );

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var album = new Album();
                    indice = reader.GetOrdinal("AlbumId");
                    album.AlbumId  = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Title");
                    album.Title = reader.GetString(indice);

                    indice = reader.GetOrdinal("ArtistId");
                    album.ArtistId = reader.GetInt32(indice);

                    result.Add(album);
                }
            }

            return result;
        }

        public int Insert(Album entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_InsertAlbum");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pTitle", entity.Title)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@pArtistId", entity.ArtistId)
                    );

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return result;
        }

        public int Update(Album entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_UpdateAlbum");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pTitle", entity.Title)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@pArtistId", entity.ArtistId)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@pId", entity.AlbumId)
                    );

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(Album entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_DeleteAlbum");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pId", entity.AlbumId)
                    );

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }
    }
}
