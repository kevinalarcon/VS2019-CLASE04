﻿using App.Entities;
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
    public class ArtistTXLocalDapperDA:BaseConnection
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
                result = cn.ExecuteScalar<int>(sql);
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
                result = cn.Query<Artist>(sql,
                    new { paramFilterByName = filterByName}
                    ).ToList();
            }

            return result;
        }


        public Artist Get(int id)
        {
            var result = new Artist();
            var sql = "SELECT * FROM Artist where ArtistId = @paramID";

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                result = cn.QueryFirstOrDefault<Artist>(sql,
                    new { paramID = id}
                    );
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
                result = cn.Query<Artist>(sql,
                        new {filterByName = filterByName},
                        commandType:CommandType.StoredProcedure).ToList() ;
            }

            return result;
        }
        
        public int Insert(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                result = cn.ExecuteScalar<int>("usp_InsertArtist",
                    new { pName = entity.Name},
                    commandType:CommandType.StoredProcedure
                    );
            }

            return result;
        }

        public bool Update(Artist entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                result = cn.Execute("usp_UpdateArtist",
                    new { pName = entity.Name,
                            pId = entity.ArtistId },
                    commandType: CommandType.StoredProcedure
                    )>0;
            }

            return result;
        }

        public bool Delete(Artist entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                result = cn.Execute("usp_DeleteArtist",
                    new { pId = entity.ArtistId},
                    commandType: CommandType.StoredProcedure
                    )>0;
            }

            return result;
        }

        public int InsertTX(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                //Abriendo la conexión a la base de datos
                //antes de iniciar la transacción
                cn.Open();

                //Iniciamos las trasnacciones
                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.ExecuteScalar<int>("usp_InsertArtist",
                    new { pName = entity.Name },
                    commandType: CommandType.StoredProcedure,
                    transaction:tx
                    );

                    //Confirmando la transacción
                    tx.Commit();
                }
                catch(Exception ex)
                {
                    //Deshacer las operaciones realizadas en la
                    //transacción
                    tx.Rollback();
                }
            }

            return result;
        }

        public bool UpdateTX(Artist entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.Execute("usp_UpdateArtist",
                    new
                    {
                        pName = entity.Name,
                        pId = entity.ArtistId
                    },
                    commandType: CommandType.StoredProcedure,
                    transaction:tx
                    ) > 0;

                    tx.Commit();
                }
                catch(Exception ex)
                {
                    tx.Rollback();
                }
            }
            return result;
        }

        public bool DeleteTX(Artist entity)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                cn.Open();

                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.Execute("usp_DeleteArtist",
                    new { pId = entity.ArtistId },
                    commandType: CommandType.StoredProcedure,
                    transaction: tx
                    ) > 0;

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                }
                
            }

            return result;
        }

    }
}
