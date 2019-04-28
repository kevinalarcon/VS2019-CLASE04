using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Data
{
    public class ArtistTXDistribuidaDA:BaseConnection
    {
        /// <summary>
        /// Permite obtener la cantidad de registros
        /// que existen en la tabla artista
        /// </summary>
        /// <returns>Retorna el número de registros</returns>
        public int GetCount() {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /*1.- Creando la instancia del objeto connection*/
            using (IDbConnection cn=new SqlConnection(this.GetConnection))
            {
                /*2.- Creando el objeto command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); // Abriendo la conexion a la base de datos;

                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artist> GetAll(string filterByName="") {
            var result = new List<Artist>();
            var sql = "SELECT * FROM Artist WHERE Name LIKE @paramFilterByName";

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
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);   
                }
            }

                return result;
        }


        public Artist Get(int id)
        {
            var result = new Artist();
            var sql = "SELECT * FROM Artist where ArtistId = @paramID";

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
                    indice = reader.GetOrdinal("ArtistId");
                    result.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    result.Name = reader.GetString(indice);

                }

            }

            return result;
        }


        public List<Artist> GetAllSP(string filterByName = "")
        {
            var result = new List<Artist>();
            /*Colocar el nombre del store procedure*/
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                IDbCommand cmd = new SqlCommand(sql);
                /*Indicar que ahora es un procedimiento almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                //Agregar el % para el parametro
                filterByName = $"%{filterByName}%";

                //Colocar el mismo nombre del parámetro del SP
                cmd.Parameters.Add(
                    new SqlParameter("@filterByName", filterByName)
                    );

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);
                }
            }

            return result;
        }
        
        public int Insert(Artist entity)
        {
            var result = 0;

            using (var trx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(base.GetConnection))
                    {
                        cn.Open();

                        IDbCommand cmd = new SqlCommand("usp_InsertArtist");
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter("@pName", entity.Name)
                            );

                        result = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    //confirma la transacciòn
                    trx.Complete();
                }
                catch(Exception ex)
                {

                }
            }

            return result;
        }

        public int Update(Artist entity)
        {
            var result = 0;

            using (var trx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(base.GetConnection))
                    {
                        cn.Open();

                        IDbCommand cmd = new SqlCommand("usp_UpdateArtist");
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter("@pName", entity.Name)
                            );
                        cmd.Parameters.Add(
                            new SqlParameter("@pId", entity.ArtistId)
                            );

                        result = cmd.ExecuteNonQuery();

                    }
                    //confirma la transacciòn
                    trx.Complete();
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }

        public int Delete(Artist entity)
        {
            var result = 0;

            using (var trx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(base.GetConnection))
                    {
                        cn.Open();

                        IDbCommand cmd = new SqlCommand("usp_DeleteArtist");
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter("@pId", entity.ArtistId)
                            );

                        result = cmd.ExecuteNonQuery();
                    }
                    //confirma la transacciòn
                    trx.Complete();
                }
                catch(Exception ex)
                {

                }
            }
            return result;
        }

    }
}
