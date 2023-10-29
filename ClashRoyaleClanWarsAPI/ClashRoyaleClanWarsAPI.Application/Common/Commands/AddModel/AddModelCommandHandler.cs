using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;

public class AddModelCommandHandler<TModel, UId> : ICommandHandler<AddModelCommand<TModel, UId>, UId>
    where TModel : IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public AddModelCommandHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result<UId>> Handle(AddModelCommand<TModel, UId> request, CancellationToken cancellationToken)
    {
        await _repository.Add(request.Model);

        return request.Model.Id;
    }
}
