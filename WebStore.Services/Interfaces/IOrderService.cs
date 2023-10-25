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
        public Task<OrderVm?> GetOrderById(Expression<Func<Order,bool>> filterExpression);
        public Task<IList<OrderVm>?> GetOrders(Expression<Func<Order, bool>>? filterExpression = null);
    }
}