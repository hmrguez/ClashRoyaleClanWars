using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands;

public class AddWarCommandHandler : AddModelCommandHandler<WarModel, int>
{
    public AddWarCommandHandler(IWarRepository repository) : base(repository)
    {
    }
}
