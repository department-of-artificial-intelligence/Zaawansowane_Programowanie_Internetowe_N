using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected BaseApiController(ILogger logger, IMapper mapper)
        {
        Logger = logger;
        Mapper = mapper;
        }
    }
}