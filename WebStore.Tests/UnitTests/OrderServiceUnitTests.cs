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
    public class OrderServiceUnitTests : BaseUnitTests
    {
        private readonly IOrderService _orderService;
        public OrderServiceUnitTests(ApplicationDbContext dbContext,
        IOrderService orderService) : base(dbContext)
        {
            _orderService = orderService;
        }
        [Fact]
        public void GetOrderTest()
        {
            var order = _orderService.GetOrder(o => o.Id == 1);
            Assert.NotNull(order);
        }

        [Fact]
        public void GetMultipleOrdersTest()
        {
            var orders = _orderService.GetOrders(p => p.Id >= 1 && p.Id <= 2);
            Assert.NotNull(orders);
            Assert.NotEmpty(orders);
            Assert.Equal(2, orders.Count());
        }

        [Fact]
        public void GetAllOrdersTest()
        {
            var orders = _orderService.GetOrders();
            Assert.NotNull(orders);
            Assert.NotEmpty(orders);
            Assert.Equal(orders.Count(), orders.Count());
        }

        [Fact]
        public void AddNewOrderTest()
        {
            var newOrderVm = new AddOrUpdateOrderVm()
            {
                Id = 1,
                CustomerId = 1,
                DeliveryDate = new DateTime(2008, 4, 1, 7, 0, 0),
                OrderDate = new DateTime(2008, 3, 1, 7, 0, 0),
                TrackingNumber = 999,
            };
            var createdOrder = _orderService.AddOrUpdateOrder(newOrderVm);
            Assert.NotNull(createdOrder);
            Assert.Equal(999, createdOrder.TrackingNumber);
        }

        [Fact]
        public void UpdateOrderTest()
        {
            var updateOrderVm = new AddOrUpdateOrderVm()
            {
                Id = 2,
                CustomerId = 1,
                DeliveryDate = new DateTime(2008, 4, 1, 7, 0, 0),
                OrderDate = new DateTime(2008, 3, 1, 7, 0, 0),
                TrackingNumber = 2,
            };
            var editedOrderVm = _orderService.AddOrUpdateOrder(updateOrderVm);
            Assert.NotNull(editedOrderVm);
            Assert.Equal(2, editedOrderVm.TrackingNumber);
        }
    }
}
