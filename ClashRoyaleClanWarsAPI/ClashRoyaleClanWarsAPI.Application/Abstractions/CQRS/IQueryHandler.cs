using ClashRoyaleClanWarsAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
