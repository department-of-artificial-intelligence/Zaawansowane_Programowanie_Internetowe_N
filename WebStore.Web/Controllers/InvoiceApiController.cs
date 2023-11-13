using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Web.Controllers
{

    public class InvoiceApiController : BaseApiController
    {
        private readonly IInvoiceService _invoiceService;
        protected InvoiceApiController(ILogger logger, IMapper mapper,
         IInvoiceService invoiceService) : base(logger, mapper)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(){
            try{
                var methodResults = await _invoiceService.GetInvoicesAsync();
                if(methodResults.Value.isExtracted)
                    return Ok(methodResults.Value.invoiceResults);
                ModelState.AddModelError("GetInvoicesAsync", "Empty collection");
                return BadRequest(ModelState);
                    
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> GetByIdAsync(int? id){
            try{
                var methodResults = await _invoiceService.GetInvoiceByIdAsync(_ => _.Id == id);
                if(methodResults.Value.isExtracted)
                    return Ok(methodResults.Value.invoice);
                ModelState.AddModelError("GetInvoiceByIdAsync", "Object is null");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteById(int? id){
            try{
                var methodResults = await _invoiceService.DeleteInvoiceAsync(_ => _.Id == id);
                if(methodResults)
                    return Ok(methodResults);
                ModelState.AddModelError("DeleteInvoiceAsync", "Id is not correct");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceVm invoiceVm)
            => await CreateOrEditHelperAsync(invoiceVm);
        [HttpPut]
        public async Task<IActionResult> Edit(InvoiceVm invoiceVm)
            => await CreateOrEditHelperAsync(invoiceVm);
        #region helpers
        public async Task<IActionResult> CreateOrEditHelperAsync(InvoiceVm invoiceVm){
            try{
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var methodResult = await _invoiceService.CreateOrUpdateInvoiceAsync(invoiceVm);
                if(methodResult.IsSuccess)
                    return Ok(methodResult.InvoiceVm);
                ModelState.AddModelError("CreateOrUpdateInvoiceAsync", "Operation is failed");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return StatusCode(500, "Error occured");
            }
        }
        #endregion
    }
}