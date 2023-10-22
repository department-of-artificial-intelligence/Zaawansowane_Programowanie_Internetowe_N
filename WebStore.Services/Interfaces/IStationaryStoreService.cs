using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IStationaryStoreService
    {
       StationaryStoreVm AddOrUpdateStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm);
       StationaryStoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression);
       IEnumerable<StationaryStoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
       void DeleteStore(int storeId);
       StationaryStoreVm GetOrderAndSendToCustomer(int storeId);
    }
}

