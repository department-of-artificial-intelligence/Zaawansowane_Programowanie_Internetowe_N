// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using AutoMapper;
// using WebStore.Services;
// using WebStore.Data;
// using WebStore.Models;

// namespace WebStore.Tests
// {
//     public class Startup
//     {
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddAutoMapper(typeof(MainProfile));
            
//             services.AddEntityFrameworkInMemoryDatabase()
//                 .AddDbContext<ApplicationDbContext>(options =>
//                     options.UseInMemoryDatabase("InMemoryDb"));
            
//             services.AddIdentity<User, IdentityRole<int>>(options =>
//             {
//                 options.SignIn.RequireConfirmedAccount = false;
//                 options.Password.RequiredLength = 6;
//                 options.Password.RequiredUniqueChars = 0;
//                 options.Password.RequireNonAlphanumeric = false;
//             })
//             .AddRoleManager<RoleManager<IdentityRole<int>>>()
//             .AddUserManager<UserManager<User>>()
//             .AddEntityFrameworkStores<ApplicationDbContext>();
            
//             services.AddTransient<ILogger, Logger<Startup>>();
            
//             // Service binding
//             services.AddTransient<IProductService, ProductService>();
//             services.AddTransient<IOrderService, OrderService>();
            
//             // … other bindings…
            
//             services.SeedData();
//         }
//     }
// }