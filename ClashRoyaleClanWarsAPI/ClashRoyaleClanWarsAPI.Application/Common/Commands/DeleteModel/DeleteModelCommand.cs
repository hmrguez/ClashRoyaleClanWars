using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;

public record DeleteModelCommand<TModel, UId>(UId Id) : ICommand
    where TModel : IEntity<UId>;
