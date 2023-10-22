using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Persistence;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Tests.UnitTests
{
    public class OrderServiceUnitTests : BaseUnitTests
    {
        private readonly IOrderService _orderService;

        public OrderServiceUnitTests(ApplicationDbContext dbContext, IOrderService orderService) : base(dbContext)
        {
            _orderService = orderService;
        }


        [Fact]
        public async Task GetOrderByIdTest()
        {
            var result = await _orderService.GetOrderByIdAsync(o => o.Id == 1);
            Assert.NotNull(result);
            Assert.IsType(typeof(OrderVm), result);
        }

        [Fact]
        public async Task TestName()
        {
            var results = await _orderService.GetOrdersAsync(x => x.TrackingNumber==15);
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            
        }
    }
}