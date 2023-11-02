using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;
public class StoreApiController : BaseApiController
{
    private readonly IStoreService _StoreService;
    public StoreApiController(ILogger logger, IMapper mapper,
    IStoreService productService)
    : base(logger, mapper)
    {
        _StoreService = productService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var products = _StoreService.GetStores();
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
            var product = _StoreService.GetStore(p => p.Id == id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateStoreVm AddOrUpdateStoreVm)
    {
        return PostOrPutHelper(AddOrUpdateStoreVm);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateStoreVm AddOrUpdateStoreVm)
    {
        return PostOrPutHelper(AddOrUpdateStoreVm);
    }
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _StoreService.DeleteStore(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateStoreVm AddOrUpdateStoreVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_StoreService.AddOrUpdateStore(AddOrUpdateStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}