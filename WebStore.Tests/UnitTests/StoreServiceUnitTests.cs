using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.EF;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests
{
    public class StoreServiceUnitTests:BaseUnitTests
    {
        private readonly IStoreService _StoreService;
        public StoreServiceUnitTests(ApplicationDbContext dbContext,IStoreService StoreService) : base(dbContext)
        {
                _StoreService=StoreService;
        }

        [Fact]
        public void GetStoreTest()
        {
            var order = _StoreService.GetStore(p => p.Id == 1);
            Assert.Null(order);
        }
        [Fact]
        public void GetAllStoresTest()
        {
            var orders = _StoreService.GetStores();
            Assert.NotNull(orders);
            Assert.NotEmpty(orders);
            Assert.Equal(orders.Count(), orders.Count());
        }
        
    }
}