using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger) { }

        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if (addOrUpdateAddressVm == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }

                var addressEntity = Mapper.Map<Address>(addOrUpdateAddressVm);

                if (addOrUpdateAddressVm.Id.HasValue && addOrUpdateAddressVm.Id > 0)
                {
                    DbContext.Addresses.Update(addressEntity);
                }
                else
                {
                    DbContext.Addresses.Add(addressEntity);
                }

                DbContext.SaveChanges();

                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public AddressVm GetAddress(int addressId)
        {
            try
            {
                var addressEntity = DbContext.Addresses.Find(addressId);

                if (addressEntity == null)
                {
                    return null;
                }

                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            try
            {
                var addressesQuery = DbContext.Addresses.AsQueryable();

                if (filterExpression != null)
                {
                    addressesQuery = addressesQuery.Where(filterExpression);
                }

                var addressVms = Mapper.Map<IEnumerable<AddressVm>>(addressesQuery);
                return addressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public AddressVm FindAddress(string postalCode, string city, string street)
        {
            try
            {
                var addressEntity = DbContext.Addresses.FirstOrDefault(address =>
                    address.ZipCode == postalCode &&
                    address.City == city &&
                    address.Street == street);

                if (addressEntity == null)
                {
                    return null;
                }

                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }     
    }
}
