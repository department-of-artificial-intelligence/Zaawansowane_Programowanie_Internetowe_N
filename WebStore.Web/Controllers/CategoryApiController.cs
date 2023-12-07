using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers{
    [Route("api/Category")]
    public class CategoryApiController : BaseApiController{
        private readonly ICategoryService _categoryservice;
        public CategoryApiController(ILogger logger, IMapper mapper, ICategoryService categoryService)
        :base(logger, mapper){
            _categoryservice = categoryService;
        }
        [HttpGet]
        public IActionResult Get(){
            try{
                var ret = _categoryservice.GetCategories();
                return Ok(ret);
            }
            catch(Exception e){
                Logger.LogError(e, e.Message);
                throw;
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateCategoryVm addOrUpdateCategoryVm){
            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                return Ok(_categoryservice.AddOrUpdateCategory(addOrUpdateCategoryVm));
            }
            catch(Exception e){
                Logger.LogError(e, e.Message);
                return StatusCode(500, "error");
            }
        }
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id){
            try{
                var predicate = _categoryservice.DeleteCategory(p => p.Id == id);
                return Ok(predicate);
            }
            catch(Exception e){
                Logger.LogError(e, e.Message);
                return StatusCode(500, "error");
            }
        }
    }
}