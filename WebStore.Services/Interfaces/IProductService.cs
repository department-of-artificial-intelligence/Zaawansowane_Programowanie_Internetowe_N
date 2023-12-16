using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;
using WebStore.Model.VM;

namespace WebStore.Services.Interfaces
{
    public interface IProductService
    {
        ProductVm AddOrUpdateProduct (AddOrUpdateProductVm addOrUpdateProductVm); 
        ProductVm GetProduct (Expression<Func<Product, bool>> filterExpression); 
        IEnumerable<ProductVm> GetProducts (Expression<Func<Product, bool>> ? filterExpression = null);
    }
}