using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm AddOrUpdateOrderVm);
        bool DeleteOrder(Expression<Func<Order,bool>> filterExpression);
        OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression);
        IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null);
    }
}