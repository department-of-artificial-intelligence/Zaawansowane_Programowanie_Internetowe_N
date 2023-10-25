using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
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

        public async Task<IList<AddressVm>?> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            try{
                IList<Address> rawAddresses= new List<Address>();
                IList<AddressVm> addressesVmResults = new List<AddressVm>();
                
                    rawAddresses = await DbContext.Addresses
                        .ToListAsync();
                    if(!rawAddresses.Any())
                        return null;

                    if(filterExpression is null){
                        addressesVmResults = Mapper.Map<IList<AddressVm>>(rawAddresses);
                        return addressesVmResults;
                    }
                    else{
                        rawAddresses = await rawAddresses.AsQueryable()
                            .Where(filterExpression)
                            .ToListAsync();

                        addressesVmResults = Mapper.Map<IList<AddressVm>>(rawAddresses);
                        return addressesVmResults;
                    }

            }
            catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<IList<AddressVm>?> GetAdressesByCustomerId(Expression<Func<Address, bool>> filterExpression)
        {
            try{
                
                if(filterExpression == null)
                    throw new Exception("The lambda expression is null");
                var rawAddresses = await DbContext.Addresses
                    .Where(filterExpression)
                    .ToListAsync();
                if(rawAddresses.Count != 0){
                    var addressesVmResults = Mapper.Map<IList<AddressVm>>(rawAddresses);
                    return addressesVmResults;
                }
                else
                    return null; 
            }
            catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}