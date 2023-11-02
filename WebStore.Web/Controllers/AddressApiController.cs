using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;
public class AddressApiController : BaseApiController
{
    private readonly IAddressService _addressService;
    public AddressApiController(ILogger logger, IMapper mapper,
    IAddressService productService)
    : base(logger, mapper)
    {
        _addressService = productService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var products = _addressService.GetAdresses();
            return Ok(products);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpGet("{id:int:min(1)}")]
    public IActionResult Get(int id)
    {
        try
        {
            var product = _addressService.GetAdress(p => p.Id == id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateAddressVm AddOrUpdateAddressVm)
    {
        return PostOrPutHelper(AddOrUpdateAddressVm);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateAddressVm AddOrUpdateAddressVm)
    {
        return PostOrPutHelper(AddOrUpdateAddressVm);
    }
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _addressService.DeleteAddress(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateAddressVm AddOrUpdateAddressVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_addressService.AddOrUpdateAddress(AddOrUpdateAddressVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}