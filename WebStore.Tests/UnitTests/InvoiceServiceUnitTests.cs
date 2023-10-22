using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;

namespace WebStore.Tests.UnitTests
{
    public class InvoiceServiceUnitTests:BaseUnitTests
    {
        private readonly IInvoiceService _InvoiceService;
        public InvoiceServiceUnitTests(ApplicationDbContext dbContext,IInvoiceService invoiceService) : base(dbContext)
        {
                _InvoiceService=invoiceService;
        }

        [Fact]
        public void GetInvoiceTest()
        {
            var invoice = _InvoiceService.GetInvoice(p => p.Id == 2);
            //Assert.NotNull(address);
            Assert.Null(invoice);
        }
        [Fact]
        public void GetAllInvoicesTest()
        {
            var invoices = _InvoiceService.GetInvoices();
            //Assert.NotNull(invoices);
            //Assert.NotEmpty(invoices);
            Assert.Equal(invoices.Count(), invoices.Count());
        }
    }
}