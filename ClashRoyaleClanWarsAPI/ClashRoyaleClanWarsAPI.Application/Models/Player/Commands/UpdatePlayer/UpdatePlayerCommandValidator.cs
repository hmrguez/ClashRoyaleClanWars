using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdatePlayer;

internal class UpdatePlayerCommandValidator : AbstractValidator<UpdateModelCommand<PlayerModel, int>>
{
    public UpdatePlayerCommandValidator()
    {
        RuleFor(x => x.Model.Alias).NotNull().NotEmpty().Length(3, 64);
        RuleFor(x => x.Model.Elo).NotNull().NotEmpty().InclusiveBetween(0, 9000);
        RuleFor(x => x.Model.Level).NotNull().NotEmpty().InclusiveBetween(1, 15);
    }
}
