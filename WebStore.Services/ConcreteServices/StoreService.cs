using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public StoreVm AddOrUpdateStore(AddOrUpdateStoreVm AddOrUpdateStoreVm)
        {
                        try
            {
                if (AddOrUpdateStoreVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var storeEntity = Mapper.Map<StationaryStore>(AddOrUpdateStoreVm);
                if (AddOrUpdateStoreVm.Id.HasValue || AddOrUpdateStoreVm.Id == 0)
                    DbContext.StationaryStores.Update(storeEntity);
                else
                    DbContext.StationaryStores.Add(storeEntity);
                DbContext.SaveChanges();
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public bool DeleteStore(Expression<Func<StationaryStore,bool>> filterExpression)
        {
            try{
                if(filterExpression==null)
                {
                    throw new ArgumentNullException("Null");
                }
                var extractedProduct= DbContext.StationaryStores.Where(filterExpression).FirstOrDefault();
                if(extractedProduct!=null)
                {
                    DbContext.Remove(extractedProduct);
                    DbContext.SaveChanges();
                    return true;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }       
        }

        public IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var storesQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpression != null)
                    storesQuery = storesQuery.Where(filterExpression);
                var storeVms = Mapper.Map<IEnumerable<StoreVm>>(storesQuery);
                return storeVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}