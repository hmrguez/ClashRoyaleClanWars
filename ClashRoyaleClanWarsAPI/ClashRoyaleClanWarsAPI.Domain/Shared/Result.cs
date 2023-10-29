using ClashRoyaleClanWarsAPI.Domain.Errors;

namespace ClashRoyaleClanWarsAPI.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != ErrorTypes.Instances.None())
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == ErrorTypes.Instances.None())
        {
            throw new InvalidOperationException();
        }
        IsSuccess = isSuccess;
        Errors = new[] { error };
    }
    protected internal Result(bool isSuccess, Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error[] Errors { get; }

    public static Result Success() => new(true, ErrorTypes.Instances.None());

    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, ErrorTypes.Instances.None());

    public static Result Failure(Error error) =>
        new(false, error);
    public static Result Failure(Error[] errors) =>
        new(false, errors);

    public static Result<TValue> Failure<TValue>(Error error) =>
        new(default, false, error);

    public static Result<TValue> Failure<TValue>(Error[] errors) =>
        new(default, false, errors);

    public static Result<TValue> Create<TValue>(TValue value) =>
        value is not null ? Success(value) : Failure<TValue>(ErrorTypes.Instances.NullValue());


}
