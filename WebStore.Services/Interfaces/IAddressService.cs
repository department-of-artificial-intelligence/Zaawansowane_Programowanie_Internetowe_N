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
        public Task<IList<AddressVm>?> GetAdressesByCustomerId(Expression<Func<Address,bool>> filterExpression);
        public Task<IList<AddressVm>?> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
    }
}