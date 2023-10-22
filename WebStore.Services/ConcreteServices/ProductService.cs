using System;
using System.Collections.Generic;
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
    public class ProductService :  BaseService, IProductService
    {
        public ProductService (ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
            : base (dbContext, mapper, logger) { }

        public ProductVm AddOrUpdateProduct (AddOrUpdateProductVm addOrUpdateProductVm) {
            try {
                if (addOrUpdateProductVm == null)
                    throw new ArgumentNullException ("View model parameter is null");
                var productEntity = _mapper.Map<Product> (addOrUpdateProductVm);
                if (addOrUpdateProductVm.Id.HasValue || addOrUpdateProductVm.Id == 0)
                _dbContext.Products.Update (productEntity);
                else
                    _dbContext.Products.Add (productEntity);
                _dbContext.SaveChanges ();
                var productVm = _mapper.Map<ProductVm> (productEntity);
                return productVm;
            } catch (Exception ex) {
                _logger.LogError (ex, ex.Message);
            throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Expression<Func<Product, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    return false;
                var extractedEntity = await _dbContext.Products
                    .Where(filterExpression)
                    .FirstOrDefaultAsync();
                if(extractedEntity is Product){
                    _dbContext.Remove(extractedEntity);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression)
        {
            try {
                if (filterExpression == null)
                    throw new ArgumentNullException ("Filter expression parameter is null");
                var productEntity = _dbContext.Products.FirstOrDefault (filterExpression);
                var productVm = _mapper.Map<ProductVm> (productEntity);
                return productVm;
            } catch (Exception ex) {
                _logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null)
        {
            try {
                var productsQuery = _dbContext.Products.AsQueryable();
                if (filterExpression != null)
                    productsQuery = productsQuery.Where(filterExpression);
                var productVms = _mapper.Map<IEnumerable<ProductVm>>(productsQuery);
                return productVms;
                } 
            catch (Exception ex) {
                _logger.LogError (ex, ex.Message);
                throw;
            }
        }
    }
}