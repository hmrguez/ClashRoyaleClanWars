using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.BattleDto;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Dtos.CollectDto;
using ClashRoyaleClanWarsAPI.Dtos.PlayerClanDto;
using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using ClashRoyaleClanWarsAPI.Dtos.WarDto;
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

            CreateMap<ClanModel, ClanModel>();
            CreateMap<PlayerClansModel, GetPlayerClanDto>();

            CreateMap<AddClanDto, ClanModel>();
            CreateMap<UpdateClanDto, ClanModel>();

            CreateMap<AddWarDto, WarModel>();

            CreateMap<AddBattleDto, BattleModel>();

            

        }

    }
}
