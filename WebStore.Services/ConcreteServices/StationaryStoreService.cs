using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StationaryStoreService : BaseService, IStationaryStoreService, IOrderService
    {
        public StationaryService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, IOrderService orderService) 
            : base(dbContext, mapper, logger) { }


        public StationaryStoreVm GetOrderAndSendToCustomer(int storeId, int customerId)
        {
            try
            {
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(s => s.Id == storeId && s.CustomerId == customerId);

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
