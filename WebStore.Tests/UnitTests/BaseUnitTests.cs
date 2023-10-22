using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Persistence;

namespace WebStore.Tests.UnitTests
{
    public abstract class BaseUnitTests
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseUnitTests (ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
    }
}