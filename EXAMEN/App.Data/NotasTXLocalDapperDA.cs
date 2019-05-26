using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace App.Data
{
    public class NotasTXLocalDapperDA:BaseConnection
    {

        public int InsertTX(Notas entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();
                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.ExecuteScalar<int>("usp_InsertNotas",
                    new { pAlumnoID = entity.AlumnoID,
                          pCursoID = entity.CursoID,
                          pNota = entity.Nota  },
                    commandType: CommandType.StoredProcedure,
                    transaction:tx
                    );

                    tx.Commit();
                }
                catch(Exception ex)
                {
                    tx.Rollback();
                }
            }

            return result;
        }

        public List<Notas> GetAllSP(int Grado, int Curso)
        {
            var result = new List<Notas>();
            var sql = "usp_GetReporte";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                result = cn.Query<Notas>(sql,
                        new { pGrado = Grado,
                              pCurso = Curso},
                        commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

    }
}
