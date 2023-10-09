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
        }
    }
}
