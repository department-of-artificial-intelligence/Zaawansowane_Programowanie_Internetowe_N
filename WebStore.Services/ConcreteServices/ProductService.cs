using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model.VM;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public ProductVm AddOrUpdateProduct(AddOrUpdateProductVm addOrUpdateProductVm)
        {
            throw new NotImplementedException();
        }

        public ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null)
        {
            throw new NotImplementedException();
        }
    }
}