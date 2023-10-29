using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;

public record GetAllModelQuery<TModel, UId>() : IQuery<IEnumerable<TModel>>
    where TModel : IEntity<UId>;
