using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public static async void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration){
            serviceCollection.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString"));
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var roles = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            if (!await roles.RoleExistsAsync("Manager"))
                await roles.CreateAsync(new IdentityRole<int>("Manager"));
        }
        
        #endregion
    }
}