using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebStore.Model;
//using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Interfaces {
    public interface IProductService {
        ProductVm AddOrUpdateProduct (AddOrUpdateProductVm addOrUpdateProductVm);
        ProductVm GetProduct (Expression<Func<ProductModel, bool>> filterExpression);
        IEnumerable<ProductVm> GetProducts (Expression<Func<ProductModel, bool>> ? filterExpression = null);
    }
}
