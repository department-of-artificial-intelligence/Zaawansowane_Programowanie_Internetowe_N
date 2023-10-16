using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        AddressVm GetAddress(int addressId);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
        AddressVm FindAddress(string postalCode, string city, string street);
    }
}
