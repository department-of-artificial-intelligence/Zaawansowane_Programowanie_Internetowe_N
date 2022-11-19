using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.ConcreteServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebStore.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebStore.ViewModels.VM;
using Microsoft.OpenApi.Models;
using WebStore.Services.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add data context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WSDatabaseConntection"));
});
builder.Services.AddAutoMapper(typeof(MainProfile));

builder.Services.Configure<JwtOptionsVm>(options => builder.Configuration.GetSection("JwtOptions").Bind(options));
builder.Services.AddIdentity<User, IdentityRole<int>>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.User.RequireUniqueEmail = false;
}).AddRoleManager<RoleManager<IdentityRole<int>>>()
.AddUserManager<UserManager<User>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
builder.Services.AddTransient(typeof(ILogger), typeof(Logger<Program>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"])),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(5)
    };
});
builder.Services.AddControllersWithViews()
.AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore API", Version = "v1" });
});
builder.Services.AddTransient<IProductService, ProductService>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore API v1"));
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html"); ;



app.Run();