using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.ExistsModelId;

public class ExistsModelIdQueryHandler<TModel, UId> : IQueryHandler<ExistsModelIdQuery<TModel, UId>, bool>
    where TModel : IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public ExistsModelIdQueryHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(ExistsModelIdQuery<TModel, UId> request, CancellationToken cancellationToken)
    {
        return await _repository.ExistsId(request.Id);
    }
}
