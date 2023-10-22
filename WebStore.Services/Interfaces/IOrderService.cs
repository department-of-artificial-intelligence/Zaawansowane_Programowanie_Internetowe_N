using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm);
        OrderVm GetOrder (Expression<Func<Order, bool>> filterExpression);
        IEnumerable<OrderVm> GetOrders (Expression<Func<Order, bool>> ? filterExpression = null);
        void DeleteOrder(int orderId);
        OrderVm AddProductToOrder(int orderId, int productId, int quantity);
        OrderVm RemoveProductFromOrder(int orderId, int productId);
    }
}