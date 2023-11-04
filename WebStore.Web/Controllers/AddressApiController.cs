using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers
{
    public class AddressApiController : BaseApiController
    {
        private readonly IAddressService _addressService;

        public AddressApiController(ILogger logger, IMapper mapper, IAddressService addressService)
            : base(logger, mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var addresses = _addressService.GetAddresses();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var address = _addressService.GetAddress(p => p.Id == id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _addressService.DeleteAddress(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        private IActionResult PostOrPutHelper(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_addressService.AddOrUpdateAddress(addOrUpdateAddressVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                return StatusCode(500, "Error occurred");
            }
        }
    }
}
