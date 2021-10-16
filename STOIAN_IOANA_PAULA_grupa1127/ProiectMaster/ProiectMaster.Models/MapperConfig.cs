using AutoMapper;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;

namespace ProiectMaster.Models
{
    public static class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductType, ProductTypeVM>();
                cfg.CreateMap<ProductTypeVM, ProductType>();

                cfg.CreateMap<Product, ProductVM>();
                cfg.CreateMap<ProductVM, Product>();

                cfg.CreateMap<Order, OrderVM>();
                cfg.CreateMap<OrderVM, Order>();

                cfg.CreateMap<OrdersProduct, OrderProductVM>();
                cfg.CreateMap<OrderProductVM, OrdersProduct>();
            });

            return config.CreateMapper();
        }
    }
}
