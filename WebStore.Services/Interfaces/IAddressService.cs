using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Interfaces;
public interface IAddressService {
    AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression);
    IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
    AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
    bool DeleteAddress(Expression<Func<Address, bool>> filterExpression);
}