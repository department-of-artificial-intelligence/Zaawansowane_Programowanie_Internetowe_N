using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.ConcreteServices
{
    
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<OrderVm?> GetOrderByIdAsync(Expression<Func<Order, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    throw new ArgumentNullException("The lambda expression is empty");
                var rawOrder = await _dbContext.Orders
                    .FirstOrDefaultAsync(filterExpression);
                if(rawOrder is Order){
                    var orderVm = _mapper.Map<OrderVm>(rawOrder);
                    return orderVm;
                }
                else
                    return null;
                
            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<IList<OrderVm>?> GetOrdersAsync(Expression<Func<Order, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    throw new ArgumentNullException("The lambda expression is null");

                var queryResults = await _dbContext.Orders
                    .Where(filterExpression)
                    .ToListAsync();

                if(queryResults.Count != 0){
                    var orderVmResults = _mapper.Map<IList<OrderVm>>(queryResults);
                    return orderVmResults;
                } 
                else
                    return null;
                
            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}