using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<UpdatePlayerDto, PlayerModel>();
            CreateMap<AddPlayerDto, PlayerModel>();

        }

    }
}
