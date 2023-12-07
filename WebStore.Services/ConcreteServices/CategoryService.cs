using System.Linq.Expressions;
using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices 
{
    public class CategoryService : BaseService, ICategoryService 
    {
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        :base(dbContext, mapper, logger) {}

        public CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm categoryVm)
        {
            try{
                var cat = Mapper.Map<Category>(categoryVm);
                if(categoryVm.Id.HasValue){
                    DbContext.Categories.Update(cat);
                }
                else{
                    DbContext.Categories.Add(cat);
                }
                DbContext.SaveChanges();
                var viewmodel = Mapper.Map<CategoryVm>(cat);
                return viewmodel;
            }
            catch(Exception e){
                Logger.LogError(e, e.Message);
                throw;
            }
        }

        public bool DeleteCategory(Expression<Func<Category, bool>> filterExpression)
        {
            try{
                if(filterExpression ==null){
                    return false;
                }
                var queryresult = DbContext.Categories.FirstOrDefault(filterExpression);
                if(queryresult != null){
                    DbContext.Categories.Remove(queryresult);
                    DbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e){
                Logger.LogError(e, e.Message);
                throw;
            }
        }

        public IEnumerable<CategoryVm> GetCategories(Expression<Func<Category, bool>>? filterExpression = null)
        {
            try{
                var query = DbContext.Categories.AsQueryable();
                if(filterExpression != null){
                    query = query.Where(filterExpression);
                }
                var ret = Mapper.Map<IEnumerable<CategoryVm>>(query);
                return ret;
            }
            catch (Exception e){
                Logger.LogError(e, e.Message);
                throw;
            }
        }

        public CategoryVm GetCategory(Expression<Func<Category, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}