using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        bool DeleteAddress(Expression<Func<Address,bool>> filterExpression);
        AddressVm GetAdress(Expression<Func<Address, bool>> filterExpression);
        IEnumerable<AddressVm> GetAdresses(Expression<Func<Address, bool>>? filterExpression = null); 
    }
}