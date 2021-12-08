using AutoMapper;
using Bob.Services.ShopCartAPI.Models;
using Bob.Services.ShopCartAPI.Models.Dto;

namespace Bob.Services.ShopCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartDto, Cart>().ReverseMap();
                config.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
