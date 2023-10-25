using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IStoreService
    {
        public Task<(IList<StationaryStoreVm>, bool isExtracted)?> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
        public Task<(StationaryStoreVm stationaryStoreVm, bool isExtracted)?> GetStoreById(Expression<Func<StationaryStore, bool>>? filterExpression = null);
    }
}