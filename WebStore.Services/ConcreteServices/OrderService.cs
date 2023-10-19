using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
            : base(dbContext, mapper, logger) { }

        public OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm)
        {
            try
            {
                if (addOrUpdateOrderVm == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }

                var orderEntity = Mapper.Map<Order>(addOrUpdateOrderVm);

                if (addOrUpdateOrderVm.Id.HasValue || addOrUpdateOrderVm.Id == 0)
                {
                    DbContext.Orders.Update(orderEntity);
                }
                else
                {
                    DbContext.Orders.Add(orderEntity);
                }

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
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }

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
                var ordersQuery = DbContext.Orders.AsQueryable(); 

                if (filterExpression != null)
                {
                    ordersQuery = ordersQuery.Where(filterExpression);
                }

                var orderVms = Mapper.Map<IEnumerable<OrderVm>>(ordersQuery);
                return orderVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public OrderVm AddProductToOrder(int orderId, int productId, int quantity)
        {
            var orderEntity = DbContext.Orders.Find(orderId);
            var productEntity = DbContext.Products.Find(productId);

            if (orderEntity != null && productEntity != null)
            {
                orderEntity.OrderProducts.Add(new OrderProduct
                {
                    Product = productEntity,
                    Quantity = quantity
                });

                DbContext.Orders.Update(orderEntity);
                DbContext.SaveChanges();
            }
            var orderVm = Mapper.Map<OrderVm>(orderEntity);
            return orderVm;
        }

        public OrderVm RemoveProductFromOrder(int orderId, int productId)
        {
            try
            {
                var orderEntity = DbContext.Orders.Find(orderId);
                var productEntity = DbContext.Products.Find(productId);

                if (orderEntity != null && productEntity != null)
                {
                    var orderProduct = orderEntity.OrderProducts.FirstOrDefault(op => op.ProductId == productId);
                    
                    if (orderProduct != null)
                    {
                        orderEntity.OrderProducts.Remove(orderProduct);
                        DbContext.Orders.Update(orderEntity);
                        DbContext.SaveChanges();
                    }
                }

                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
