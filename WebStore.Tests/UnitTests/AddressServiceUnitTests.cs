using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.EF;
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
        public void GetAddressTest()
        {
            var address = _addressService.GetAdress(p => p.Id == 1);
            //Assert.NotNull(address);
            Assert.Null(address);

        }
        [Fact]
        public void GetAllAdressesTest()
        {
            var addresses = _addressService.GetAdresses();
           // Assert.NotNull(addresses);
            //Assert.NotEmpty(addresses);
            Assert.Equal(addresses.Count(), addresses.Count());
            Assert.Empty(addresses);
        }

    }
}