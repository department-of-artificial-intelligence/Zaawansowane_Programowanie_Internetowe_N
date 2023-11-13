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

    public class OrderApiController : BaseApiController
    {
        private readonly IOrderService _orderService;
        protected OrderApiController(ILogger logger, IMapper mapper,
            IOrderService orderService) : base(logger, mapper)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(){
            try{
                var methodResult = await _orderService.GetOrdersAsync();
                if(methodResult.Any())
                    return Ok(methodResult);
                ModelState.AddModelError("GetOrdersAsync", "Empty collection");
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
                var methodResult = await _orderService.GetOrderByIdAsync(_ => _.Id == id);
                if(methodResult is not null)
                    return Ok(methodResult);
                ModelState.AddModelError("GetOrderByIdAsync", "Result is null");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteByIdAsync(int? id){
            try{
                var methodResult = await _orderService.DeleteOrderAsync(_ => _.Id == id);
                if(methodResult)
                    return Ok(methodResult);
                ModelState.AddModelError("DeleteOrderAsync", "Operation is failed");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(OrderVm orderVm)
            => await CreateOrEditHelperAsync(orderVm);

        [HttpPut]
        public async Task<IActionResult> CreateAsync(OrderVm orderVm)
            => await CreateOrEditHelperAsync(orderVm);

        #region helpers
        public async Task<IActionResult> CreateOrEditHelperAsync(OrderVm orderVm){
            try{
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var methodResults = await _orderService.CreateOrUpdateOrder(orderVm);
                if(methodResults.IsSuccess)
                    return Ok(methodResults.OrderVm);
                ModelState.AddModelError("CreateOrUpdateOrder", "Operation is failed");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return StatusCode(500,"Error occurred");
            }
        }
        #endregion
    }
}