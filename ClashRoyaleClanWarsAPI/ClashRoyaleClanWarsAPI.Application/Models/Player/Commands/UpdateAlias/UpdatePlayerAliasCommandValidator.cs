using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateAlias;

internal class UpdatePlayerAliasCommandValidator : AbstractValidator<UpdatePlayerAliasCommand>
{
    public UpdatePlayerAliasCommandValidator()
    {
        RuleFor(x => x.Alias).NotNull().NotEmpty().Length(3, 64);
    }
}
