using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.Model.Entities;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.Mappings
{
    public class MainProfile : Profile
    {
        
        public MainProfile()
        {

            CreateMap<Product, ProductVm>();
            CreateMap<ProductVm, Product>();
            CreateMap<Product, AddOrUpdateProductVm>();
            CreateMap<AddOrUpdateProductVm, Product>();

            CreateMap<Order,OrderVm>();
            CreateMap<OrderVm,Order>();

            CreateMap<Address, AddressVm>();
            CreateMap<AddressVm, Address>();

            CreateMap<User,UserVm>()
                .Include<Customer, CustomerVm>()
                .Include<Supplier, SupplierVm>();
            CreateMap<Customer,CustomerVm>();
            CreateMap<Supplier, SupplierVm>();

            CreateMap<Invoice, InvoiceVm>();
            CreateMap<InvoiceVm, Invoice>();

            CreateMap<StationaryStore, StationaryStoreVm>();
            CreateMap<StationaryStoreVm, StationaryStore>();
        }
    }
}