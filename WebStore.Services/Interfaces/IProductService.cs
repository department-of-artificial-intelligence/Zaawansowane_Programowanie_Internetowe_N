using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.Models;

namespace WebStore.Services.Interfaces;

public interface IProductService
{
    ProductViewModel AddOrUpdateProduct (AddOrUpdateProductViewModel addOrUpdateProductVm);
    ProductViewModel GetProduct (Expression<Func<Product, bool>> filterExpression);
    IEnumerable<ProductViewModel> GetProducts (Expression<Func<Product, bool>> ? filterExpression = null);

}