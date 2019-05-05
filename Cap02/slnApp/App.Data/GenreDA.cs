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
    public class GenreDA:BaseConnection
    {
        public Genre Get(int id)
        {
            var result = new Genre();
            var sql = "SELECT * FROM Genre where GenreId = @paramID";

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
                    indice = reader.GetOrdinal("GenreId");
                    result.GenreId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    result.Name = reader.GetString(indice);

                }

            }

            return result;
        }

        public List<Genre> GetAll(string filterByName = "")
        {
            var result = new List<Genre>();
            var sql = "SELECT * FROM Genre WHERE Name LIKE @paramFilterByName";

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
                    var genre = new Genre();
                    indice = reader.GetOrdinal("GenreId");
                    genre.GenreId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    genre.Name = reader.GetString(indice);

                    result.Add(genre);
                }
            }

            return result;
        }

        public int Insert(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_InsertGenre");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pName", entity.Name)
                    );

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return result;
        }

        public int Update(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_UpdateGenre");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pName", entity.Name)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@pId", entity.GenreId)
                    );

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_DeleteGenre");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@pId", entity.GenreId)
                    );

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }
    }
}
