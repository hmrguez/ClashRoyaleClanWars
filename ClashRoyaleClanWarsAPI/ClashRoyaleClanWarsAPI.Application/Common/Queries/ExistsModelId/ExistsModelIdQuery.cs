using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.ExistsModelId;

public record ExistsModelIdQuery<TModel, UId>(UId Id) : IQuery<bool>
    where TModel : IEntity<UId>;
