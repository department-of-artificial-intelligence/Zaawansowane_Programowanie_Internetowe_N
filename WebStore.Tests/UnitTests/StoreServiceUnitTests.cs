using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using Xunit.Sdk;

namespace WebStore.Tests.UnitTests
{
    public class StoreServiceUnitTests : BaseUnitTests
    {
        private readonly IStoreService _storeService;
        public StoreServiceUnitTests(ApplicationDbContext dbContext, IStoreService storeService) : base(dbContext)
        {
            _storeService = storeService;
        }

        [Fact]
        public async Task GetStoresTestAsync()
        {
            var rawResults = await _storeService.GetStoresAsync();
            var preparedResult = rawResults.GetValueOrDefault().isExtracted;
            Assert.NotNull(preparedResult);
            Assert.Equal(true, preparedResult);
        }

        [Fact]
        public async  Task GetStoreByIdTestAsync()
        {
            var rawResults = await _storeService.GetStoreByIdAsync(x => x.Id == 1);
            var preparedResult = rawResults.GetValueOrDefault().isExtracted;
            Assert.NotNull(preparedResult);
            Assert.Equal(true, preparedResult);
        }
        [Fact]
        public async Task  DeleteStoreTestAsync()
        {
            var methodResult = await _storeService.DeleteStoreAsync(_ => _.Id == 1);
            Assert.Equal(true, methodResult);
            Assert.NotNull(methodResult);
        }
        [Fact]
        public async Task CreateStoreTestAsync()
        {
            var newStationaryStoreVm= new StationaryStoreVm();
            var methodResults = await _storeService.CreateOrUpdateStoreAsync(newStationaryStoreVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }
        [Fact]
        public async Task EditStoreTestAsync()
        {
            var updatedAddress = new AddressVm(){
                Id = 1,
                BillingAddress = "Test",
                ShippingAddress = "Test"
                
            };
            var updateStationaryStoreVm = new StationaryStoreVm(){
                Id = 1,
                Addresses = new List<AddressVm>(){updatedAddress}
            };
            var methodResults = await _storeService.CreateOrUpdateStoreAsync(updateStationaryStoreVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }
    }
}