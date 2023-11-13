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

    public class AddressApiController : BaseApiController
    {
        private readonly IAddressService _addressService;
        protected AddressApiController(ILogger logger, IMapper mapper,
            IAddressService addressService) : base(logger, mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(){
            try{
                var methodResult = await _addressService.GetAddressesAsync();
                if(methodResult.Any())
                    return Ok(methodResult);
                ModelState.AddModelError("GetAddressesAsync", "Empty collection");
                return BadRequest(ModelState);

            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int? id){
            try{
                var methodResults = await _addressService.GetAdressesByCustomerIdAsync(_ => _.Id == id);
            if(methodResults.Any())
                return Ok(methodResults);
            ModelState.AddModelError("GetAdressesByCustomerIdAsync", "Empty collection");
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
                var methodResults = await _addressService.DeleteAddressAsync(_ => _.Id == id);
                if(methodResults)
                    return Ok(methodResults);
                ModelState.AddModelError("GetAdressesByCustomerIdAsync", "Empty collection");
                return BadRequest(ModelState);
            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]AddressVm addressVm)
            => await CreateOrEditHelperAsync(addressVm);

        [HttpPut]
        public async Task<IActionResult> EditAsync([FromBody]AddressVm addressVm)
            => await CreateOrEditHelperAsync(addressVm);


        #region helpers
        private  async Task<IActionResult> CreateOrEditHelperAsync(AddressVm addressVm){
            try{
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var methodResults = await _addressService.CreateOrUpdateAddress(addressVm);
                if(methodResults.IsSuccess)
                    return Ok(methodResults.AddressVm);
                return BadRequest("Error occurred");

            }catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return StatusCode(500,"Error occurred");
            }
        }
        #endregion

    }
}