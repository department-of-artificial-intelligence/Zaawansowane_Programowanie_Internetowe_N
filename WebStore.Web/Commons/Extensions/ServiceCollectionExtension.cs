using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Persistence;

namespace WebStore.Web.Commons.Extensions
{
    /// <summary>
    /// Class responsible for provide services
    /// </summary>
    public static class ServiceCollectionExtension
    {
        #region methods
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration){
            serviceCollection.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString"));
            });
        }
        #endregion
    }
}