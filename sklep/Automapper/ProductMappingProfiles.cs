using AutoMapper;
using sklep.Dtos;
using sklep.Models;

namespace sklep.Automapper
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductGetDto>();
        }
    }
}
