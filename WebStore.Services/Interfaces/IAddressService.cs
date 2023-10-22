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
        public Task<IList<AddressVm>?> GetAdressesByCustomerIdAsync(Expression<Func<Address,bool>> filterExpression);
        public Task<IList<AddressVm>?> GetAddressesAsync(Expression<Func<Address, bool>>? filterExpression = null);
    }
}