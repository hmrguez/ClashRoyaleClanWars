using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;

namespace ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;

public class DeleteModelCommandHandler<TModel, UId> : ICommandHandler<DeleteModelCommand<TModel, UId>>
    where TModel : IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public DeleteModelCommandHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteModelCommand<TModel, UId> request, CancellationToken cancellationToken)
    {
        TModel model;
        try
        {
            model = await _repository.GetSingleByIdAsync(request.Id);
        }
        catch (IdNotFoundException<UId> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }
            
        await _repository.Delete(model);

        return Result.Success();
    }
}
