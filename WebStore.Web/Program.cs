using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Services.Interfaces;
using WebStore.Services.ConcreteServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStationaryStoreService, StationaryStoreService>();
builder.Services.AddLogging(configure => configure.AddConsole()); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
