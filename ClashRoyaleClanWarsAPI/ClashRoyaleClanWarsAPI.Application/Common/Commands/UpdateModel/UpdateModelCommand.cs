using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;

public record UpdateModelCommand<TModel, UId>(TModel Model) : ICommand
    where TModel : IEntity<UId>;
