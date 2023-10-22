using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Persistence;
using WebStore.Services.Interfaces;

namespace WebStore.Tests.UnitTests
{
    public class InvoiceServiceUnitTests : BaseUnitTests
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceServiceUnitTests(ApplicationDbContext dbContext, IInvoiceService invoiceService) : base(dbContext)
        {
            _invoiceService = invoiceService;
        }

        [Fact]
        public async Task GetInvoiceByIdTest()
        {
            var rawResult = await _invoiceService.GetInvoiceByIdAsync(i => i.Id == 1);
            var preparedResult = rawResult.GetValueOrDefault().invoice;
            Assert.NotNull(preparedResult);
        }

        [Fact]
        public async Task GetInvoicesTest()
        {
            var rawResult = await _invoiceService.GetInvoicesAsync();
            var preparedResult = rawResult.GetValueOrDefault().isExtracted;
            Assert.Equal(false, preparedResult);
        }
    }
}