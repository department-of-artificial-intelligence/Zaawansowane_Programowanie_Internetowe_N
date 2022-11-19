using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging; 
using WebStore.DAL.EF; 
using WebStore.Model.DataModels; 
using WebStore.Services.ConcreteServices; 
using WebStore.Services.Configuration; 
using WebStore.Services.Interfaces;



namespace WebStore.Tests { 
    public class Startup { 
        public void ConfigureServices (IServiceCollection services) { 
            services.AddAutoMapper (typeof (MainProfile)); 
            services.AddEntityFrameworkInMemoryDatabase () 
                .AddDbContext<ApplicationDbContext> (
                    options => options.UseInMemoryDatabase ("InMemoryDb") 
                ); 
                    
            services.AddIdentity<User, IdentityRole<int>> (options => { 
                options.SignIn.RequireConfirmedAccount = false; 
                options.Password.RequiredLength = 6; 
                options.Password.RequiredUniqueChars = 0; 
                options.Password.RequireNonAlphanumeric = false; 
                 }) 
                .AddRoleManager<RoleManager<IdentityRole<int>>> () 
                .AddUserManager<UserManager<User>> () 
                .AddEntityFrameworkStores<ApplicationDbContext> (); 
            services.AddTransient (typeof (ILogger), typeof (Logger<Startup>)); 
            // service binding 
            services.AddTransient<IProductService, ProductService> ();
            services.AddTransient<IInvoiceService, InvoiceService> (); 
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IStoreService, StoreService>();
            // … other bindings… 
            services.SeedData (); 
            } 
        } 
    }