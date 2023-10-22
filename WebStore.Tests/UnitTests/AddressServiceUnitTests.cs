using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;

namespace WebStore.Tests.UnitTests
{
    public class AddressServiceUnitTests : BaseUnitTests
    {
        private readonly IAddressService _addressService;
        public AddressServiceUnitTests(ApplicationDbContext dbContext, IAddressService addressService) : base(dbContext)
        {
            _addressService = addressService;
        }

        [Fact]
        public async Task GetAllProductTest()
        {
            
            var results = await _addressService.GetAddressesAsync();
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.NotEqual(0, results.Count);
        }

        [Fact]
        public async Task GetAdressesByCustomerIdTest()
        {
            var results = await _addressService.GetAdressesByCustomerIdAsync(a => a.CustomerId == 3);
            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}