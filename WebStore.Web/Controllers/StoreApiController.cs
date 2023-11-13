using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Web.Controllers
{

    public class StoreApiController : BaseApiController
    {
        private readonly IStoreService _storeService;
        protected StoreApiController(ILogger logger, IMapper mapper,
            IStoreService storeService) : base(logger, mapper)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(){
            try{
                var methodResults = await _storeService.GetStoresAsync();
                if(methodResults.Value.isExtracted)
                    return Ok(methodResults.Value.StationaryStores);
                ModelState.AddModelError("GetStoresAsync", "Operation is failed");
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
                var methodResults = await _storeService.GetStoreByIdAsync(_ => _.Id == id);
                if(methodResults.Value.isExtracted)
                    return Ok(methodResults.Value.stationaryStoreVm);
                ModelState.AddModelError("GetStoreByIdAsync", "Operation is failed");
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
                var methodResult = await _storeService.DeleteStoreAsync(_ => _.Id == id);
                if(methodResult)
                    return Ok(methodResult);
                ModelState.AddModelError("GetStoreByIdAsync", "Operation is failed");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(StationaryStoreVm stationaryStoreVm)
            => await CreateOrEditHelperAsync(stationaryStoreVm);

        [HttpPut]
        public async Task<IActionResult> EditAsync(StationaryStoreVm stationaryStoreVm)
            => await CreateOrEditHelperAsync(stationaryStoreVm);
        #region helpers
        public async Task<IActionResult> CreateOrEditHelperAsync(StationaryStoreVm stationaryStoreVm){
            try{
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var methodResults = await _storeService.CreateOrUpdateStoreAsync(stationaryStoreVm);
                if(methodResults.IsSuccess)
                    return Ok(methodResults.StationaryStoreVm);
                ModelState.AddModelError("CreateOrUpdateStoreAsync", "Operation is failed");
                return BadRequest(ModelState);
                
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return StatusCode(500, "Error occured");
            }
        }
        #endregion

    }
}