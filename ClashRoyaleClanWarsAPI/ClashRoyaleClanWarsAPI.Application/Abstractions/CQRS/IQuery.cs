using ClashRoyaleClanWarsAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
