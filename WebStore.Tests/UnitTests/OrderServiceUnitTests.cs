using Microsoft.EntityFrameworkCore;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class OrderServiceUnitTests : BaseUnitTests
{
    private readonly IOrderService _service;
    private readonly ApplicationDbContext _context;
    public OrderServiceUnitTests(ApplicationDbContext dbContext,
        IOrderService orderService) : base(dbContext)
    {
        _service = orderService;
        _context = dbContext;
    }

    [Fact]
    public void GetOrderTest()
    {
        var order = _service.GetOrder(p => p.TrackingNumber == 1101022);
        Assert.NotNull(order);
    }

    [Fact]
    public void GetMultipleOrdersTest()
    {
        var orders = _service.GetOrders(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(orders);
        Assert.NotEmpty(orders);
        Assert.Equal(2, orders.Count());
    }

    [Fact]
    public void GetAllOrdersTest()
    {
        var orders = _service.GetOrders();
        Assert.NotNull(orders);
        Assert.NotEmpty(orders);
        Assert.Equal(orders.Count(), orders.Count());
    }

    [Fact]
    public void AddNewOrderTest()
    {
        var newOrderVm = new AddOrUpdateOrderVm()
        {
            CustomerId = 1,
            DeliveryDate = new DateTime(2020, 10, 10),
            Invoiceid = 1,
            StationaryStoreId = 1
        };

        var createdOrder = _service.AddOrUpdateOrder(newOrderVm);
        Assert.NotNull(createdOrder);
        Assert.Equal(createdOrder.DeliveryDate, new DateTime(2020, 10, 10));
    }

    [Fact]
    public void UpdateOrderTest()
    {
        var updateOrderVm = new AddOrUpdateOrderVm()
        {
            CustomerId = 2,
            DeliveryDate = new DateTime(2020, 5, 5),
            Invoiceid = 1,
            StationaryStoreId = 1
        };
        var editedOrderVm = _service.AddOrUpdateOrder(updateOrderVm);
        Assert.NotNull(editedOrderVm);
        Assert.Equal(2, editedOrderVm.CustomerId);
        Assert.Equal(new DateTime(2020, 5, 5), editedOrderVm.DeliveryDate);
    }

    [Fact]
    public async Task DeleteOrderTest()
    {
        int orderId = 3;

        bool doesOrderExistsBefore = await _context.Order.AnyAsync(x => x.Id == orderId);
        await _service.DeleteOrder(x => x.Id == orderId);
        bool doesOrderExistsAfter = await _context.Order.AnyAsync(x => x.Id == orderId);

        Assert.True(doesOrderExistsBefore);
        Assert.False(doesOrderExistsAfter);
    }
}