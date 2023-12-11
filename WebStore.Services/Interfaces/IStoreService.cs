using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Interfaces
{
    public interface IStoreService
    {
        StoreVm AddOrUpdateStore(AddOrUpdateStoreVm AddOrUpdateStoreVm);
        bool DeleteStore(Expression<Func<StationaryStore,bool>> filterExpression);

        StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression);
        IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
    }
}