using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }

        public OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm)
        {
            try
            {
                if (addOrUpdateOrderVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var orderEntity = Mapper.Map<Order>(addOrUpdateOrderVm);
                if (addOrUpdateOrderVm.Id.HasValue || addOrUpdateOrderVm.Id == 0)
                    DbContext.Orders.Update(orderEntity);
                else
                    DbContext.Orders.Add(orderEntity);
                DbContext.SaveChanges();
                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var orderEntity = DbContext.Orders.FirstOrDefault(filterExpression);
                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null)
        {
            try
            {
                var orderQuery = DbContext.Orders.AsQueryable();
                if (filterExpression != null)
                    orderQuery = orderQuery.Where(filterExpression);
                var orderVm = Mapper.Map<IEnumerable<OrderVm>>(orderQuery);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
            bool IOrderService.DeleteOrder(Expression<Func<Order, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}