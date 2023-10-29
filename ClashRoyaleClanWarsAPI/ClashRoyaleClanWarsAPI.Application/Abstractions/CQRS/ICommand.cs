using ClashRoyaleClanWarsAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
