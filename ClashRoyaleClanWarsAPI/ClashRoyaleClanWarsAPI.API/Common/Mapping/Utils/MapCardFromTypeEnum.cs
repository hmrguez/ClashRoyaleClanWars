using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;

namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Utils;

public static class MapCardFromTypeEnum
{
    public static CardModel MapCard(CardRequest cardRequest, IMapper mapper)
    {
        return cardRequest.Type switch
        {
            TypeCardEnum.Spell => mapper.Map<SpellModel>(cardRequest),
            TypeCardEnum.Troop => mapper.Map<TroopModel>(cardRequest),
            TypeCardEnum.Structure => mapper.Map<StructureModel>(cardRequest),
            _ => null!
        };
    }
}
