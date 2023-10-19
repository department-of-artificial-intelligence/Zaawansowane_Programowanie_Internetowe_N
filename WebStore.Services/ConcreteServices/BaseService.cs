using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;

namespace WebStore.Services.ConcreteServices
{
    /// <summary>
    /// Provider for interfaces
    /// </summary>
    public abstract class BaseService
    {
        #region properties and constructors
        protected readonly ApplicationDbContext _dbContext;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        public BaseService (ApplicationDbContext dbContext,
            IMapper mapper, ILogger logger) {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
    }
}