using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            throw new NotImplementedException();
        }

        public AddressVm GetAdress(Expression<Func<Address, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var addressEntity = DbContext.Address.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }        }

        public IEnumerable<AddressVm> GetAdresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            try
            {
                var AddresssQuery = DbContext.Address.AsQueryable();
                if (filterExpression != null)
                    AddresssQuery = AddresssQuery.Where(filterExpression);
                var AddressVms = Mapper.Map<IEnumerable<AddressVm>>(AddresssQuery);
                return AddressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }    
        }
    }
}