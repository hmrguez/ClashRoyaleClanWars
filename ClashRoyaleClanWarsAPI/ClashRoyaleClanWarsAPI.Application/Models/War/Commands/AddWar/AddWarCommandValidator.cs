using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddWar;

internal class AddWarCommandValidator : AbstractValidator<AddModelCommand<WarModel, int>>
{
    public AddWarCommandValidator()
    {
        RuleFor(x => x.Model.StartDate).NotNull();
    }
}
