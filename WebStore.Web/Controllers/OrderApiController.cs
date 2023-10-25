using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;


public class OrderApiController : BaseApiController
{
    
        private readonly IOrderService _orderService;
    public OrderApiController(ILogger logger, IMapper mapper, IOrderService orderService) : base(logger, mapper)
    {
        _orderService = orderService;
    }


[HttpGet]
public IActionResult Get()
{
    try
    {
        var orders = _orderService.GetOrders();
        return Ok(orders);
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
            var orders = _orderService.GetOrders(p => p.Id == id);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }



















}