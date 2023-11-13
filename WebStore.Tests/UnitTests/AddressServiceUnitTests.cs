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

        [Fact]
        public async Task DeleteAddressTestAsync()
        {
            var methodResult = await _addressService.DeleteAddressAsync(_ => _.Id == 1);
            Assert.Equal(true, methodResult);
            Assert.NotNull(methodResult);
        }

        [Fact]
        public async Task CreateAddressTestAsync(){
            var newAddressVm = new AddressVm(){
                Id = 1,
                BillingAddress = "42480 Emilie Run, Goldnerfort, HI 03739-8988",
                ShippingAddress = "639 Shalanda Shore, Mosciskiton, NH 89850-6735"
                
            };
            var methodResults = await _addressService.CreateOrUpdateAddress(newAddressVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);
        }

        [Fact]
        public async void EditAddressTestAsync()
        {
            var newAddressVm = new AddressVm(){
                BillingAddress = "Test",
                ShippingAddress = "Test"
            };
            var methodResults = await _addressService.CreateOrUpdateAddress(newAddressVm);
            Assert.Equal(true, methodResults.IsSuccess);
            Assert.NotNull(methodResults);

        }
    }
}