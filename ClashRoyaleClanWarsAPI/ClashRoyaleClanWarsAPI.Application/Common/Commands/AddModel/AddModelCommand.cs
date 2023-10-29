using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;

public record AddModelCommand<TModel, UId>(TModel Model) : ICommand<UId>
    where TModel : IEntity<UId>;
