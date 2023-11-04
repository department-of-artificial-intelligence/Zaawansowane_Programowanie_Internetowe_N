using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers
{
    public class StationaryStoreApiController : BaseApiController
    {
        private readonly IStationaryStoreService _stationaryStoreService;

        public StationaryStoreApiController(ILogger logger, IMapper mapper,  IStationaryStoreService stationaryStoreServiceService)
            : base(logger, mapper)
        {
            _stationaryStoreService = stationaryStoreServiceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var stores = _stationaryStoreService.GetStores();
                return Ok(stores);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var store = _stationaryStoreService.GetStore(p => p.Id == id);
                return Ok(store);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
            return PostOrPutHelper(addOrUpdateStationaryStoreVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
            return PostOrPutHelper(addOrUpdateStationaryStoreVm);
        }

        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _stationaryStoreService.DeleteStore(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occurred");
            }
        }

        private IActionResult PostOrPutHelper(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_stationaryStoreService.AddOrUpdateStore(addOrUpdateStationaryStoreVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                return StatusCode(500, "Error occurred");
            }
        }
    }
}
