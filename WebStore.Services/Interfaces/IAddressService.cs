using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        ProductVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        ProductVm GetAddress(Expression<Func<Address, bool>> filterExpression);
        IEnumerable<ProductVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
    }
}