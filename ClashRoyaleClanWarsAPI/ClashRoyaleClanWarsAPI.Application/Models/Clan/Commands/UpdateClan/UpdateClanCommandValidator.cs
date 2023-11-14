using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.UpdateClan;

internal class UpdateClanCommandValidator : AbstractValidator<UpdateModelCommand<ClanModel, int>>
{
    public UpdateClanCommandValidator()
    {
        RuleFor(x => x.Model.Name).NotEmpty().NotNull().Length(3, 64);
        RuleFor(x => x.Model.Region).NotEmpty().NotNull().Length(3, 32);
        RuleFor(x => x.Model.TypeOpen).NotNull();
        RuleFor(x => x.Model.MinTrophies).NotNull().GreaterThanOrEqualTo(0);
    }
}
