using AutoMapper;
using WebStore.Model;
using WebStore.ViewModels;
using WebStore.ViewModels.VM;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressVm>();
        CreateMap<Product, ProductVm>();
        CreateMap<Order, OrderVm>();
        CreateMap<Invoice, InvoiceVm>();
        CreateMap<StationaryStore, StationaryStoreVm>();
    }
}
