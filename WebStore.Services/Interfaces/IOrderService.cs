using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.Entities;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderVm?> GetOrderByIdAsync(Expression<Func<Order,bool>> filterExpression);
        public Task<IList<OrderVm>?> GetOrdersAsync(Expression<Func<Order, bool>>? filterExpression = null);
        public Task<(bool IsSuccess, OrderVm OrderVm)> CreateOrUpdateOrder(OrderVm orderVm);
        public Task<bool> DeleteOrderAsync(Expression<Func<Order,bool>> filterExpression);
    }
}