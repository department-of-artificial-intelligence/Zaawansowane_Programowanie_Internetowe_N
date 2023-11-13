using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.Entities;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        public Task<IList<AddressVm>?> GetAdressesByCustomerIdAsync(Expression<Func<Address,bool>> filterExpression);
        public Task<IList<AddressVm>?> GetAddressesAsync(Expression<Func<Address, bool>>? filterExpression = null);
        public Task<bool> DeleteAddressAsync(Expression<Func<Address, bool>> filterExpression);
        public Task<(bool IsSuccess, AddressVm AddressVm)> CreateOrUpdateAddress(AddressVm addressVm);
    }
}