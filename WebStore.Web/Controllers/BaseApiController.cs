using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class BaseApiController : Controller
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