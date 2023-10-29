using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;

public record GetModelByIdQuery<TModel, UId>(UId Id) : IQuery<TModel>
    where TModel : IEntity<UId>;
