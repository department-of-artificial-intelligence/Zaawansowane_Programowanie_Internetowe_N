using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;


namespace WebStore.Services.ConcreteServices
{

    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
        {
            
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
            throw new NotImplementedException();
        }
    }
}
