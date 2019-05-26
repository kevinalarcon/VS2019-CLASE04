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
    public class AlumnoDA : BaseConnection
    {
        public List<Alumno> GetAllSP()
        {
            var result = new List<Alumno>();
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var alumno = new Alumno();
                    indice = reader.GetOrdinal("AlumnoId");
                    alumno.AlumnoId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Nombres");
                    alumno.Nombres= reader.GetString(indice);

                    indice = reader.GetOrdinal("Apellidos");
                    alumno.Apellidos = reader.GetString(indice);

                    indice = reader.GetOrdinal("Direccion");
                    alumno.Direccion = reader.GetString(indice);

                    indice = reader.GetOrdinal("Sexo");
                    alumno.Sexo = reader.GetString(indice);

                    indice = reader.GetOrdinal("FechaNacimiento");
                    alumno.FechaNacimiento = reader.GetDateTime(indice);

                    result.Add(alumno);
                }
            }

            return result;
        }

        public int Insert(Alumno entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                IDbCommand cmd = new SqlCommand("usp_InsertAlumno");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@Nombres", entity.Nombres)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@Apellidos", entity.Apellidos)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@Direccion", entity.Direccion)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@Sexo", entity.Sexo)
                    );
                cmd.Parameters.Add(
                    new SqlParameter("@FechaNacimiento", entity.FechaNacimiento)
                    );

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return result;
        }
    }
}
