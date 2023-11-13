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
        public async Task GetInvoiceByIdTestAsync()
        {
            var rawResult = await _invoiceService.GetInvoiceByIdAsync(i => i.Id == 1);
            var preparedResult = rawResult.GetValueOrDefault().invoice;
            Assert.NotNull(preparedResult);
        }

        [Fact]
        public async Task GetInvoicesTestAsync()
        {
            var rawResult = await _invoiceService.GetInvoicesAsync();
            var preparedResult = rawResult.GetValueOrDefault().isExtracted;
            Assert.Equal(false, preparedResult);
        }

        [Fact]
        public async Task DeleteInvoiceTestAsync()
        {
            var methodResult = await _invoiceService.DeleteInvoiceAsync(_ => _.Id == 1);
            Assert.Equal(true,methodResult);
            Assert.NotNull(methodResult);
        }
        [Fact]
        public async Task CreateInvoiceTestAsync()
        {
            var newInvoiceVm =new InvoiceVm(){
                Id = 1,
                DeliveryDate = new DateTime(2023,10,21),
                OrderDate = new DateTime(2023, 10, 25),
            };
            var methodResults = await _invoiceService.CreateOrUpdateInvoiceAsync(newInvoiceVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }
        [Fact]
        public async Task EditInvoiceTestAsync()
        {
            var updatedInvoiceVm =new InvoiceVm(){
                DeliveryDate = new DateTime(2023,11,21),
                OrderDate = new DateTime(2023, 11, 25),
            };
            var methodResults = await _invoiceService.CreateOrUpdateInvoiceAsync(updatedInvoiceVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }
    }
}