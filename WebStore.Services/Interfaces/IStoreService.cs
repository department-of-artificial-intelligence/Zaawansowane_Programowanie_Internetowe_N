using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.Entities;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.Interfaces
{
    public interface IStoreService
    {
        public Task<(IList<StationaryStoreVm>, bool isExtracted)?> GetStoresAsync(Expression<Func<StationaryStore, bool>>? filterExpression = null);
        public Task<(StationaryStoreVm stationaryStoreVm, bool isExtracted)?> GetStoreByIdAsync(Expression<Func<StationaryStore, bool>>? filterExpression = null);
        public Task<bool> DeleteStoreAsync(Expression<Func<StationaryStore, bool>> filterExpression);
        public Task<(bool IsSuccess, StationaryStoreVm StationaryStoreVm )> CreateOrUpdateStoreAsync(StationaryStoreVm stationaryStoreVm);
    }
}