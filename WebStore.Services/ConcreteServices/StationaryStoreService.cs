using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.Model;
using WebStore.Services.Interfaces;

namespace WebStore.Services.ConcreteServices
{
    public class StationaryStoreService : BaseService, IStationaryStoreService
    {
        public StationaryStoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
            : base(dbContext, mapper, logger) { }


        public StationaryStoreVm GetOrderAndSendToCustomer(int storeId, int customerId)
        {
            try
            {
                 var stationaryStoreEntity = DbContext.StationaryStores
                    .Include(s => s.Customers) 
                    .FirstOrDefault(s => s.Id == storeId && s.Customers.Any(c => c.Id == customerId));

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
