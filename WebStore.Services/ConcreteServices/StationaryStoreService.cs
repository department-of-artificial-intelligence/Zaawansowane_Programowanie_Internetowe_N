using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StationaryStoreService : BaseService, IStationaryStoreService
    {
        public StationaryStoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
            : base(dbContext, mapper, logger) { }


        public StationaryStoreVm AddOrUpdateStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
            try
            {
                if (addOrUpdateStationaryStoreVm == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }

                var stationaryStoreEntity = Mapper.Map<StationaryStore>(addOrUpdateStationaryStoreVm);

                if (addOrUpdateStationaryStoreVm.Id.HasValue || addOrUpdateStationaryStoreVm.Id == 0)
                {
                    DbContext.StationaryStores.Update(stationaryStoreEntity);
                }
                else
                {
                    DbContext.StationaryStores.Add(stationaryStoreEntity);
                }

                DbContext.SaveChanges();

                var stationaryStoreVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);
                return stationaryStoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StationaryStoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }

                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var stationaryVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);
                return stationaryVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StationaryStoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var stationaryStoresQuery = DbContext.StationaryStores.AsQueryable();

                if (filterExpression != null)
                {
                    stationaryStoresQuery = stationaryStoresQuery.Where(filterExpression);
                }

                var stationaryStoreVms = Mapper.Map<IEnumerable<StationaryStoreVm>>(stationaryStoresQuery);
                return stationaryStoreVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void DeleteStore(int storeId)
        {
            try
            {
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(st => st.Id == storeId);

                if (stationaryStoreEntity == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }
                else
                {
                    DbContext.StationaryStores.Remove(stationaryStoreEntity);
                }
                 DbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // to fix
        public StationaryStoreVm GetOrderAndSendToCustomer(int storeId)
        {
            try
            {
                 var stationaryStoreEntity = DbContext.StationaryStores
                    .FirstOrDefault(s => s.Id == storeId);

                if (stationaryStoreEntity != null)
                {     
                   var stationaryStoreVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);

                    DbContext.Add(stationaryStoreVm);
                    DbContext.SaveChanges();

                    return stationaryStoreVm;
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
