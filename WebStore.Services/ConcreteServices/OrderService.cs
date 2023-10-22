using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
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

        public void DeleteOrder(int orderId)
        {
            try
            {
                var orderEntity = DbContext.Orders.FirstOrDefault(o => o.Id == orderId);

                if (orderEntity == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }
                else
                {
                    DbContext.Orders.Remove(orderEntity);
                }
                 DbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public OrderVm AddProductToOrder(int orderId, int productId, int quantity)
        {
            try
            {
                var orderEntity = DbContext.Orders.FirstOrDefault(o => o.Id == orderId);
                var productEntity = DbContext.Products.FirstOrDefault(p => p.Id == productId);

                if (orderEntity != null && productEntity != null)
                {
                    var orderProductEntity = DbContext.OrderProducts
                        .FirstOrDefault(op => op.ProductId == productId);

                    if (orderProductEntity != null)
                    {
                        orderProductEntity.Quantity += quantity;
                    }
                    else
                    {
                        orderProductEntity = new OrderProduct
                        {
                            ProductId = productId,
                            OrderId = orderId,
                            Quantity = quantity,
                            Product = productEntity,
                            Order = orderEntity
                        };

                        DbContext.OrderProducts.Add(orderProductEntity);
                    }
                    DbContext.SaveChanges();
                }

                var updatedOrderEntity = DbContext.Orders.FirstOrDefault(o => o.Id == orderId);
                var orderVm = Mapper.Map<OrderVm>(updatedOrderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public OrderVm RemoveProductFromOrder(int orderId, int productId)
        {
            try
            {
                var orderEntity = DbContext.Orders.FirstOrDefault(o => o.Id == orderId);
                var productEntity = DbContext.Products.FirstOrDefault(p => p.Id == productId);

                if (orderEntity != null && productEntity != null)
                {
                    var orderProduct = DbContext.OrderProducts.FirstOrDefault(op => op.ProductId == productId);
                    
                    if (orderProduct != null)
                    {
                        DbContext.OrderProducts.Remove(orderProduct);
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
