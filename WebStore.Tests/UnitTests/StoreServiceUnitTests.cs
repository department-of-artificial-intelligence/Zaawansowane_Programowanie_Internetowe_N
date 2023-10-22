using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Persistence;
using WebStore.Services.Interfaces;

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
        public async Task GetStoresTest()
        {
            var rawResults = await _storeService.GetStoresAsync();
            var preparedResult = rawResults.GetValueOrDefault().isExtracted;
            Assert.NotNull(preparedResult);
            Assert.Equal(true, preparedResult);
        }


        
        [Fact]
        public async  Task GetStoreByIdTest()
        {
            var rawResults = await _storeService.GetStoreByIdAsync(x => x.Id == 1);
            var preparedResult = rawResults.GetValueOrDefault().isExtracted;
            Assert.NotNull(preparedResult);
            Assert.Equal(true, preparedResult);
        }
    }
}