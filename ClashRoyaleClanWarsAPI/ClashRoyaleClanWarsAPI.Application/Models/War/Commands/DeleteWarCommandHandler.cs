using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands;

public class DeleteWarCommandHandler : DeleteModelCommandHandler<WarModel, int>
{
    public DeleteWarCommandHandler(IWarRepository repository) : base(repository)
    {
    }
}
