using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;


namespace WebStore.Services.ConcreteServices
{

    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
        {
        }

        public ProductVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            throw new NotImplementedException();
        }

        public ProductVm GetAddress(Expression<Func<Address, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            throw new NotImplementedException();
        }
    }

}
