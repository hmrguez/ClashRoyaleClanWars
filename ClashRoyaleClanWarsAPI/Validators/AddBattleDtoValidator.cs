using ClashRoyaleClanWarsAPI.Dtos.BattleDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class AddBattleDtoValidator:AbstractValidator<AddBattleDto>
    {
        public AddBattleDtoValidator()
        {
            RuleFor(abdto => abdto.AmountTrophies)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(10, 50);

            RuleFor(abdto => abdto.DurationInSeconds)
                .NotEmpty()
                .NotNull()
                .GreaterThan(30);

            RuleFor(abdto => abdto.WinnerId)
                .NotNull()
                .NotEqual(dto=> dto.LoserId);

            RuleFor(abdto => abdto.LoserId)
                .NotNull()
                .NotEqual(dto => dto.WinnerId);
        }
    }
}
