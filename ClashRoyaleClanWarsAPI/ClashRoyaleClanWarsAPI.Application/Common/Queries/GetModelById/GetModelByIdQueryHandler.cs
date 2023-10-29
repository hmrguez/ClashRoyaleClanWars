using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;

namespace ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;

public class GetModelByIdQueryHandler<TModel, UId> : IQueryHandler<GetModelByIdQuery<TModel, UId>, TModel>
    where TModel : IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public GetModelByIdQueryHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<TModel>> Handle(GetModelByIdQuery<TModel, UId> request, CancellationToken cancellationToken)
    {
        TModel model;

        try
        {
            model = await _repository.GetSingleByIdAsync(request.Id);
        }
        catch (IdNotFoundException<UId> e)
        {
            return Result.Failure<TModel>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return model;
    }
}
