using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;
public class OrderApiController : BaseApiController
{
    private readonly IOrderService _OrderService;
    public OrderApiController(ILogger logger, IMapper mapper,
    IOrderService productService)
    : base(logger, mapper)
    {
        _OrderService = productService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var products = _OrderService.GetOrders();
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
            var product = _OrderService.GetOrder(p => p.Id == id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateOrderVm AddOrUpdateOrderVm)
    {
        return PostOrPutHelper(AddOrUpdateOrderVm);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateOrderVm AddOrUpdateOrderVm)
    {
        return PostOrPutHelper(AddOrUpdateOrderVm);
    }
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _OrderService.DeleteOrder(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateOrderVm AddOrUpdateOrderVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_OrderService.AddOrUpdateOrder(AddOrUpdateOrderVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}