using AutoMapper;
using sklep.Dtos;
using sklep.Models;

namespace sklep.Automapper
{
    public class ShopMappingProfiles : Profile
    {
        public ShopMappingProfiles()
        {
            CreateMap<ShopCreateDto, Shop>();
            CreateMap<Shop, ShopGetDto>();

        }
    }
}
