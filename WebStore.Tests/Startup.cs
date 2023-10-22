using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;
using WebStore.Services.Mappings;
using WebStore.Tests.Utils;

namespace WebStore.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper(typeof(MainProfile));
            services.AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb")
            );
            services.AddIdentity<User, IdentityRole<int>> (options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoleManager<RoleManager<IdentityRole<int>>>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient(typeof(ILogger),typeof(Logger<Startup>));
            // service binding
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            // … other bindings…
            services.SeedData ();
        }
    }
}