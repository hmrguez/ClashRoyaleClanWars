namespace ClashRoyaleClanWarsAPI.Domain.Shared;

public interface IValidationResult
{
    Error[] Errors { get; }
}
