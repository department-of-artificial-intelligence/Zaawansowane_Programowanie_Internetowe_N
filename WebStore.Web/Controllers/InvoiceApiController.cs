using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;
public class InvoiceApiController : BaseApiController
{
    private readonly IInvoiceService _InvoiceService;
    public InvoiceApiController(ILogger logger, IMapper mapper,
    IInvoiceService productService)
    : base(logger, mapper)
    {
        _InvoiceService = productService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var products = _InvoiceService.GetInvoices();
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
            var product = _InvoiceService.GetInvoice(p => p.Id == id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateInvoiceVm AddOrUpdateInvoiceVm)
    {
        return PostOrPutHelper(AddOrUpdateInvoiceVm);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateInvoiceVm AddOrUpdateInvoiceVm)
    {
        return PostOrPutHelper(AddOrUpdateInvoiceVm);
    }
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _InvoiceService.DeleteInvoice(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateInvoiceVm AddOrUpdateInvoiceVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_InvoiceService.AddOrUpdateInvoice(AddOrUpdateInvoiceVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}