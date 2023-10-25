using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;

namespace WebStore.Web.Controllers;


public class StoreApiController : BaseApiController
{
    private readonly IStoreService _storeService;
    public StoreApiController(ILogger logger, IMapper mapper, IStoreService storeService) : base(logger, mapper)
    {
        _storeService = storeService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var stores = _storeService.GetStores();
            return Ok(stores);
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
            var stores = _storeService.GetStoreById(p => p.Id == id);
            return Ok(stores);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
}
