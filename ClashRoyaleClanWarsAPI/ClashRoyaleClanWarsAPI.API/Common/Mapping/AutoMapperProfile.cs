using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Auth;
using ClashRoyaleClanWarsAPI.Application.Common.Mapping;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.API.Common.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CardRequest, SpellModel>();
        CreateMap<CardRequest, TroopModel>();
        CreateMap<CardRequest, StructureModel>();

        CreateMap<AddPlayerRequest, PlayerModel>();
        CreateMap<UpdatePlayerRequest, PlayerModel>();

        CreateMap<PlayerModel, PlayerModel>();
        CreateMap<CollectionModel, CollectionDto>();

        CreateMap<WarModel, WarModel>();
        CreateMap<ClanWarsModel, ClanWarDto>();

        CreateMap<AddBattleRequest, BattleModel>();

        CreateMap<AddClanRequest, ClanModel>();
        CreateMap<UpdateClanRequest, ClanModel>();

        CreateMap<ClanModel, ClanModel>();
        CreateMap<ClanPlayersModel, ClanPlayerDto>();

        CreateMap<AddWarRequest, WarModel>();

        CreateMap<LoginRequest, LoginModel>();
        CreateMap<RegisterRequest, RegisterModel>();

        CreateMap<AddChallengeRequest, ChallengeModel>();
        CreateMap<UpdateChallengeRequest, ChallengeModel>();
    }
}
