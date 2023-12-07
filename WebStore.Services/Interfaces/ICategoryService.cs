using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces{
    public interface ICategoryService {
        CategoryVm GetCategory(Expression<Func<Category, bool>> filterExpression);
        CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm categoryVm);
        IEnumerable<CategoryVm> GetCategories(Expression<Func<Category,bool>>? filterExpression = null);
        bool DeleteCategory(Expression<Func<Category, bool>> filterExpression);
    }
}