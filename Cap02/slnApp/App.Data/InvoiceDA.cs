using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Entities;
using Dapper;

namespace App.Data
{
    public class InvoiceDA:BaseConnection
    {
        public int InsertarTXLocal(Invoice invoice)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnection))
            {
                //Abriendo la conexion a la base de datos
                cn.Open();
                //Iniciando la transaccion
                var tx = cn.BeginTransaction();
                try
                {
                    var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                        new
                        {
                            CustomerId = invoice.CustomerId,
                            InvoiceDate = invoice.InvoiceDate,
                            BillingAddress = invoice.BillingAddress,
                            BillingCity = invoice.BillingCity,
                            BillingState = invoice.BillingState,
                            BillingCountry = invoice.BillingCountry,
                            BillingPostalCode = invoice.BillingPostalCode,
                            Total = invoice.Total
                        }, commandType: CommandType.StoredProcedure,
                            transaction: tx
                        );

                    foreach (var item in invoice.InvoiceLine)
                    {
                        cn.Execute("usp_InsertInvoiceLine",
                            new
                            {
                                InvoiceId = invoiceId,
                                TrackId = item.TrackId,
                                UnitPrice = item.UnitPrice,
                                Quantity = item.Quantity
                            }, commandType: CommandType.StoredProcedure,
                            transaction: tx
                            );

                        throw new Exception("Error");
                    }

                    result = invoiceId;

                    //Confirmando la transacción
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    //Deshaciendo la transacción
                    tx.Rollback();
                }

            }

                return result;
        }

        public int InsertarTXDist(Invoice invoice)
        {
            var result = 0;

            using (var tx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(base.GetConnection))
                    {

                        var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                            new
                            {
                                CustomerId = invoice.CustomerId,
                                InvoiceDate = invoice.InvoiceDate,
                                BillingAddress = invoice.BillingAddress,
                                BillingCity = invoice.BillingCity,
                                BillingState = invoice.BillingState,
                                BillingCountry = invoice.BillingCountry,
                                BillingPostalCode = invoice.BillingPostalCode,
                                Total = invoice.Total
                            }, commandType: CommandType.StoredProcedure
                            );

                        foreach (var item in invoice.InvoiceLine)
                        {
                            cn.Execute("usp_InsertInvoiceLine",
                                new
                                {
                                    InvoiceId = invoiceId,
                                    TrackId = item.TrackId,
                                    UnitPrice = item.UnitPrice,
                                    Quantity = item.Quantity
                                }, commandType: CommandType.StoredProcedure
                                );

                            //throw new Exception("Error");
                        }

                        result = invoiceId;
                    }
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    result = 0;
                }
            }

            return result;
        }

    }
}
