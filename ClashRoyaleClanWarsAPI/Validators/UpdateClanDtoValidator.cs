using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class UpdateClanDtoValidator: AbstractValidator<UpdateClanDto>
    {
        public UpdateClanDtoValidator()
        {
            RuleFor(acdto => acdto.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(64);

            RuleFor(acdto => acdto.Region)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(32);

            RuleFor(acdto => acdto.MinTrophies)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(0)
                .GreaterThanOrEqualTo(9999);
        }
    }
}
