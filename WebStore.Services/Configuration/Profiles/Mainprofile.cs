using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using WebStore.DAL.EF;
using WebStore.Model;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Configuration.Profiles;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile(){
            CreateMap<Product,ProductVm>();
            CreateMap<AddOrUpdateProductVm,Product>();

        }
    }
}