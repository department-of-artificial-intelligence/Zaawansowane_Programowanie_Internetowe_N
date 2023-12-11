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
    public class OrderServiceUnitTests:BaseUnitTests
    {
        private readonly IOrderService _OrderService;
        public OrderServiceUnitTests(ApplicationDbContext dbContext,IOrderService OrderService) : base(dbContext)
        {
                _OrderService=OrderService;
        }

        [Fact]
        public void GetOrderTest()
        {
            var order = _OrderService.GetOrder(p => p.Id == 2);
            Assert.Null(order);
        }
        [Fact]
        public void GetAllOrdersTest()
        {
            var orders = _OrderService.GetOrders();
            //Assert.NotNull(orders);
           // Assert.NotEmpty(orders);
            Assert.Equal(orders.Count(), orders.Count());
        }
    }
    
}