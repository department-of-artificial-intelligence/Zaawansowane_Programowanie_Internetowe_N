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
        public async Task GetOrderByIdTestAsync()
        {
            var result = await _orderService.GetOrderByIdAsync(o => o.Id == 1);
            Assert.NotNull(result);
            Assert.IsType(typeof(OrderVm), result);
        }

        [Fact]
        public async Task GetOrdersTestAsync()
        {
            var results = await _orderService.GetOrdersAsync(x => x.TrackingNumber==15);
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            
        }

        [Fact]
        public async Task DeleteOrderTestAsync()
        {
            var methodResult = await _orderService.DeleteOrderAsync(_ => _.Id == 1);
            Assert.Equal(true, methodResult);
            Assert.NotNull(methodResult);
        }
        [Fact]
        public async Task CreateOrderTestAsync()
        {
            var newOrderVm = new OrderVm(){
                DeliveryDate = new DateTime(2023,10,25),
                OrderDate = new DateTime(2023,10,27),
                TotalAmount = 50.0m,
                TrackingNumber = 60
            };
            var methodResults = await _orderService.CreateOrUpdateOrder(newOrderVm);
            Assert.Equal(true,methodResults.IsSuccess);
            Assert.NotNull(methodResults);

        }
        [Fact]
        public async Task EditOrderTestAsync()
        {
            var updateOrderVm = new OrderVm(){
                Id = 3,
                DeliveryDate = new DateTime(2023,11,25),
                OrderDate = new DateTime(2023,11,27),
                TotalAmount = 115.0m,
                TrackingNumber = 90
            };
            var methodResults  = await _orderService.CreateOrUpdateOrder(updateOrderVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }
    }
}