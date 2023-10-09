using ClashRoyaleClanWarsAPI.Dtos.WarDto;
using FluentValidation;

namespace ClashRoyaleClanWarsAPI.Validators
{
    public class AddWarDtoValidator : AbstractValidator<AddWarDto>
    {
        public AddWarDtoValidator()
        {
            RuleFor(awdto => awdto.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
