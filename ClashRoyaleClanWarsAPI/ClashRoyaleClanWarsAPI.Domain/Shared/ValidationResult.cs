﻿namespace ClashRoyaleClanWarsAPI.Domain.Shared;

public class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, errors)
    {
        Errors = errors;
    }

    public new Error[] Errors { get; }

    public static ValidationResult Create(Error[] errors)
    {
        return new ValidationResult(errors);
    }
}
