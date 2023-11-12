using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandValidator : AbstractValidator<AddBattleCommand>
{
    public AddBattleCommandValidator()
    {
        RuleFor(x => x.WinnerId).NotEmpty().NotEqual(t => t.LoserId);
        RuleFor(x => x.LoserId).NotEmpty().NotEqual(t => t.WinnerId);

        RuleFor(x => x.Battle.AmountTrophies).InclusiveBetween(10, 40);
        RuleFor(x => x.Battle.DurationInSeconds).InclusiveBetween(1, 300);
        RuleFor(x => x.Battle.Date).NotNull();
    }
}
