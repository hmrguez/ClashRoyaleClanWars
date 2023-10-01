using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Dtos.CollectDto;
using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<PlayerModel, PlayerModel>();
            CreateMap<CollectModel, GetCollectDto>();

            CreateMap<UpdatePlayerDto, PlayerModel>();
            CreateMap<AddPlayerDto, PlayerModel>();

            CreateMap<AddClanDto, ClanModel>();
            CreateMap<UpdateClanDto, ClanModel>();

        }

    }
}
