using AutoMapper;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Configuration;
public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<AddOrUpdateProductVm, Product>();
        CreateMap<Address, AddressVm>();
        CreateMap<Category, CategoryVm>();
        CreateMap<CustomerAddress, CustomerAddressVm>();
        CreateMap<CustomerVm, Customer>();
        CreateMap<InvoiceVm, Invoice>();
        CreateMap<Order, OrderVm>()
            .ForMember(dest => dest.Products, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Product != null ? y.Product : null)));
        CreateMap<ProductStockVm, ProductStock>();
        CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.Orders, x => x
            .MapFrom(src => src.OrderProducts
            .Select(y => y.Order != null ? y.Order : null)));
        CreateMap<Product, AddOrUpdateProductVm>();
        CreateMap<StationaryStoreAddressVm, StationaryStoreAddress>();
        CreateMap<StationaryStoreEmployeeVm, StationaryStore>();
        CreateMap<StationaryStoreVm, StationaryStore>();
        CreateMap<SupplierVm, Supplier>();
        CreateMap<UserVm, User>();
    }

}