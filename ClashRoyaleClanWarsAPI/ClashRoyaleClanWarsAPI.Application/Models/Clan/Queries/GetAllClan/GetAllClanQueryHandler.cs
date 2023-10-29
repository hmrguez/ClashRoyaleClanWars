using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllClan;

public class GetAllClanQueryHandler : GetAllModelQueryHandler<ClanModel, int>
{
    public GetAllClanQueryHandler(IClanRepository repository) : base(repository)
    {
    }
}
