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
            var order = _orderService.GetOrder(o => o.TrackingNumber == 123456789);
            Assert.NotNull(order);
        }



        // [Fact]
        // public void GetMultipleOrdersTest()
        // {
        //     var orders = _orderService.GetOrders(p => p.Id >= 1 && p.Id <= 2);
        //     Assert.NotNull(orders);
        //     Assert.NotEmpty(orders);
        //     Assert.Equal(2, orders.Count());
        // }
        // [Fact]
        // public void GetAllOrdersTest()
        // {
        //     var orders = _orderService.GetOrders();
        //     Assert.NotNull(orders);
        //     Assert.NotEmpty(orders);
        //     Assert.Equal(orders.Count(), orders.Count());
        // }









//         [Fact]
//         public void AddNewOrderTest()
//         {
//             var newOrderVm = new AddOrUpdateOrderVm()
//             {
//                 Name = "MacBook Pro",
//                 CategoryId = 1,
//                 SupplierId = 1,
//                 ImageBytes = new byte[] {
// 0xff,
// 0xff,
// 0xff,
// 0x80
// },
//                 Price = 6000,
//                 Weight = 1.1f,
//                 Description = "MacBook Pro z procesorem M1 8GB RAM, Dysk 256 GB"
//             };
//             var createdOrder = _orderService.AddOrUpdateOrder(newOrderVm);
//             Assert.NotNull(createdOrder);
//             Assert.Equal("MacBook Pro", createdOrder.Name);
//         }
//         [Fact]
//         public void UpdateOrderTest()
//         {
//             var updateOrderVm = new AddOrUpdateOrderVm()
//             {
//                 Id = 1,
//                 Description = "Bardzo praktyczny monitor 32 cale",
//                 ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
//                 Name = "Monitor Dell 32",
//                 Price = 2000,
//                 Weight = 20,
//                 CategoryId = 1,
//                 SupplierId = 1
//             };
//             var editedOrderVm = _orderService.AddOrUpdateOrder(updateOrderVm);
//             Assert.NotNull(editedOrderVm);
//             Assert.Equal("Monitor Dell 32", editedOrderVm.Name);
//             Assert.Equal(2000, editedOrderVm.Price);
//         }

        
    }
}
