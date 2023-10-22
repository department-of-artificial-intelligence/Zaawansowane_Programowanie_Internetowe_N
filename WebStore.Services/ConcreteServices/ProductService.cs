using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.Models;

namespace WebStore.Services.ConcreteServices;

public class ProductService : BaseService, IProductService
{
    public ProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
    {
    }

    public ProductViewModel AddOrUpdateProduct(AddOrUpdateProductViewModel addOrUpdateProductVm)
    {
        try
        {
            if (addOrUpdateProductVm == null)
                throw new ArgumentNullException("View model parameter is null");
            var productEntity = Mapper.Map<Product>(addOrUpdateProductVm);
            if (addOrUpdateProductVm.Id.HasValue || addOrUpdateProductVm.Id == 0)
                DbContext.Products.Update(productEntity);
            else
                DbContext.Products.Add(productEntity);
            DbContext.SaveChanges();
            var productVm = Mapper.Map<ProductViewModel>(productEntity);
            return productVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public ProductViewModel GetProduct(Expression<Func<Product, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");
            var productEntity = DbContext.Products.FirstOrDefault(filterExpression);
            var productVm = Mapper.Map<ProductViewModel>(productEntity);
            return productVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<ProductViewModel> GetProducts(Expression<Func<Product, bool>>? filterExpression = null)
    {
        try
        {
            var productsQuery = DbContext.Products.AsQueryable();
            if (filterExpression != null)
                productsQuery = productsQuery.Where(filterExpression);
            var productVms = Mapper.Map<IEnumerable<ProductViewModel>>(productsQuery);
            return productVms;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IActionResult DeleteProduct(Expression<Func<Product, bool>> filterExpression)
    {
        return null;
    }
}