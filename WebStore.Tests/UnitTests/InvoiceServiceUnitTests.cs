using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
    public class InvoiceServiceUnitTests : BaseUnitTests
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceServiceUnitTests(ApplicationDbContext dbContext,
        IInvoiceService invoiceService) : base(dbContext)
        {
            _invoiceService = invoiceService;
        }
        [Fact]
        public void GetInvoiceTest()
        {
            var invoice = _invoiceService.GetInvoice(p => p.InvoiceNumber == 2022010101);
            Assert.NotNull(invoice);
        }
        [Fact]
        public void GetMultipleInvoicesTest()
        {
            var invoices = _invoiceService.GetInvoices(p => p.Id >= 1 && p.Id <= 2);
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            Assert.Equal(1, invoices.Count());
        }
        [Fact]
        public void GetAllInvoicesTest()
        {
            var invoices = _invoiceService.GetInvoices();
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            Assert.Equal(invoices.Count(), invoices.Count());
        }
        
    }
}
