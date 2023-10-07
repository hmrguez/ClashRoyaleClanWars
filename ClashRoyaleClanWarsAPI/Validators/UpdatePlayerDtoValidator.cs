using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class UpdatePlayerDtoValidator : AbstractValidator<UpdatePlayerDto>
    {
        public UpdatePlayerDtoValidator()
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
                .GreaterThanOrEqualTo(0);

            RuleFor(apdto => apdto.Victories)
                .GreaterThanOrEqualTo(0);
        }
    }
}
