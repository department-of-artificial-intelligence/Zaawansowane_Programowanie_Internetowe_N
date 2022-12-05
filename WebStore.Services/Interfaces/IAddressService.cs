using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        public AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression);
        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
        public Task DeleteAddress(Expression<Func<Address, bool>> filterExpression);
    }
}