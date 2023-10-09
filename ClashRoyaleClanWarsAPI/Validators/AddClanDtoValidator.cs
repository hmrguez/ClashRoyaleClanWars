using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class AddClanDtoValidator:AbstractValidator<AddClanDto>
    {
        public AddClanDtoValidator()
        {
            RuleFor(acdto=> acdto.Name)
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
