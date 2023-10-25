using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StoreService : BaseService , IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<(StationaryStoreVm stationaryStoreVm, bool isExtracted)?> GetStoreById(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    return (null, false);
                var rawStationaryStore = await DbContext.StationaryStores
                    .FirstOrDefaultAsync();
                if(rawStationaryStore is StationaryStore){
                    var stationaryStoreVmResult = Mapper.Map<StationaryStoreVm>(rawStationaryStore);
                    return (stationaryStoreVmResult, true);
                }
                return (null, false);
            }
            catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<(IList<StationaryStoreVm>, bool isExtracted)?> GetStores(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try{
                IList<StationaryStore> rawResults = new List<StationaryStore>();
                IList<StationaryStoreVm> stationaryStoreVmResults  = new List<StationaryStoreVm>();
                
                rawResults = await DbContext.StationaryStores
                    .ToListAsync();
                if(!rawResults.Any())
                    return (null, false);
                    
                stationaryStoreVmResults = Mapper.Map<IList<StationaryStoreVm>>(rawResults);
                if(filterExpression is null)
                    return (stationaryStoreVmResults, true);
                else{
                    rawResults = await rawResults.AsQueryable()
                        .Where(filterExpression)
                        .ToListAsync();
                    stationaryStoreVmResults = Mapper.Map<IList<StationaryStoreVm>>(rawResults);
                    return (stationaryStoreVmResults,true);

                }


            }
            catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}