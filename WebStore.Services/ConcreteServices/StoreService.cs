using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.ConcreteServices
{
    public class StoreService : BaseService , IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<(bool IsSuccess, StationaryStoreVm StationaryStoreVm)> CreateOrUpdateStoreAsync(StationaryStoreVm? stationaryStoreVm)
        {
            try{
                if(stationaryStoreVm == null)
                    return(false,null);
                var preparedEntity = _mapper.Map<StationaryStore>(stationaryStoreVm);
                if(preparedEntity is null)
                    return(false,null);
                if(stationaryStoreVm.Id.HasValue || stationaryStoreVm.Id == 0){
                    
                    _dbContext.StationaryStores.Update(preparedEntity);
                    await _dbContext.SaveChangesAsync();
                    return(true,stationaryStoreVm);
                }else{
                    await _dbContext.StationaryStores.AddAsync(preparedEntity);
                    await _dbContext.SaveChangesAsync();
                    return(true,stationaryStoreVm);
                }
                
            }catch(Exception ex){
                 _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<bool> DeleteStoreAsync(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    return(false);
                var extractedStationaryStore = await  _dbContext.StationaryStores.FirstOrDefaultAsync(filterExpression);
                if(extractedStationaryStore is null)
                    return(false);
                _dbContext.StationaryStores.Remove(extractedStationaryStore);
                await _dbContext.SaveChangesAsync();
                return true;

            }catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

    

        public async Task<(StationaryStoreVm stationaryStoreVm, bool isExtracted)?> GetStoreByIdAsync(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try{
                if(filterExpression is null)
                    return (null, false);
                var rawStationaryStore = await _dbContext.StationaryStores
                    .FirstOrDefaultAsync();
                if(rawStationaryStore is StationaryStore){
                    var stationaryStoreVmResult = _mapper.Map<StationaryStoreVm>(rawStationaryStore);
                    return (stationaryStoreVmResult, true);
                }
                return (null, false);
            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<(IList<StationaryStoreVm>, bool isExtracted)?> GetStoresAsync(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try{
                IList<StationaryStore> rawResults = new List<StationaryStore>();
                IList<StationaryStoreVm> stationaryStoreVmResults  = new List<StationaryStoreVm>();
                
                rawResults = await _dbContext.StationaryStores
                    .ToListAsync();
                if(!rawResults.Any())
                    return (null, false);
                    
                stationaryStoreVmResults = _mapper.Map<IList<StationaryStoreVm>>(rawResults);
                if(filterExpression is null)
                    return (stationaryStoreVmResults, true);
                else{
                    rawResults = await rawResults.AsQueryable()
                        .Where(filterExpression)
                        .ToListAsync();
                    stationaryStoreVmResults = _mapper.Map<IList<StationaryStoreVm>>(rawResults);
                    return (stationaryStoreVmResults,true);

                }


            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}