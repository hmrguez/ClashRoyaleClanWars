using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandValidator : AbstractValidator<AddClanCommand>
{
    public AddClanCommandValidator()
    {
        RuleFor(x => x.Clan.Name).NotEmpty().NotNull().Length(3, 64);
        RuleFor(x => x.Clan.Region).NotEmpty().NotNull().Length(3, 32);
        RuleFor(x => x.Clan.TypeOpen).NotEmpty().NotNull();
        RuleFor(x => x.Clan.MinTrophies).NotEmpty().NotNull().GreaterThanOrEqualTo(0);

    }
}
