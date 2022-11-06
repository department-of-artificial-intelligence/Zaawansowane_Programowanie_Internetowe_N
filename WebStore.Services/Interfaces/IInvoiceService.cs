using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IInvoiceService
    {
        public ProductVm AddOrUpdateProduct(AddOrUpdateProductVm addOrUpdateProductVm);
        public ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression);
        public IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null);



    }
}