using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;

public class GetAllModelQueryHandler<TModel, UId> : IQueryHandler<GetAllModelQuery<TModel, UId>, IEnumerable<TModel>>
    where TModel : IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public GetAllModelQueryHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<TModel>>> Handle(GetAllModelQuery<TModel, UId> request, CancellationToken cancellationToken)
    {
        IEnumerable<TModel> models = await _repository.GetAllAsync();

        return Result.Create(models);
    }
}
