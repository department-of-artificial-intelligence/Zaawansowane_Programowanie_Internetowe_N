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
       StationaryStoreVm GetOrderAndSendToCustomer(int storeId, int customerId);
    }
}

