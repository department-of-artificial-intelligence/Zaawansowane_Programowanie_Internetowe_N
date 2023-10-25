using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;

namespace WebStore.Web.Controllers;

public class InvoiceApiController : BaseApiController
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceApiController(ILogger logger, IMapper mapper, IInvoiceService invoiceService) : base(logger, mapper)
    {
        _invoiceService = invoiceService;
    }

[HttpGet]
public IActionResult Get()
{
    try
    {
        var invoices = _invoiceService.GetInvoices();
        return Ok(invoices);
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
            var invoices = _invoiceService.GetInvoiceById(p => p.Id == id);
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
}