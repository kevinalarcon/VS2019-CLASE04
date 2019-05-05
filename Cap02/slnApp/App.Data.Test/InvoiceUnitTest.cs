using System;
using System.Collections.Generic;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class InvoiceUnitTest
    {
        [TestMethod]
        public void InsertTXLocal()
        {
            var invoiceDA = new InvoiceDA();

            var invoice = new Invoice();
            invoice.CustomerId = 67;
            invoice.BillingCountry = "Lima";
            invoice.BillingAddress = "Av Los alamos 233";
            invoice.BillingCity = "Lima";
            invoice.BillingPostalCode = "Lima32";
            invoice.BillingState = "Lima";
            invoice.InvoiceDate = DateTime.Now;
            invoice.Total = 300;

            //Agregando los detalles
            invoice.InvoiceLine = new List<InvoiceLine>();
            //---1
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    Quantity = 2,
                    UnitPrice = 50
                }
                );

            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 4,
                    UnitPrice = 50
                }
                );


            var id = invoiceDA.InsertarTXLocal(invoice);

            Assert.IsTrue(id > 0);
        }
    }
}
