using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class AddPlayerDtoValidator : AbstractValidator<AddPlayerDto>
    {
        public AddPlayerDtoValidator()
        {
            RuleFor(apdto => apdto.Alias)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32)
                .MinimumLength(4);

            RuleFor(apdto => apdto.Level)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 14);

            RuleFor(apdto => apdto.Elo)
                .InclusiveBetween(0, 9999);

            RuleFor(apdto => apdto.Victories)
                .GreaterThanOrEqualTo(0);
        }
    }
}
