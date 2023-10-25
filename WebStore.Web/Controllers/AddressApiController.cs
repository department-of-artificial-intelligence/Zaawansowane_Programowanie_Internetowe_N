using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;

namespace WebStore.Web.Controllers;

public class AddressApiController : BaseApiController
{
    private readonly IAddressService _addressService;
    public AddressApiController(ILogger logger, IMapper mapper, IAddressService addressService) : base(logger, mapper)
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
            return StatusCode(500, "Error occured");
        }
    }
    [HttpGet("{id:int:min(1)}")]
    public IActionResult Get(int id)
    {
        try
        {
            var addresses = _addressService.GetAdressesByCustomerId(p => p.Id == id);
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
}
