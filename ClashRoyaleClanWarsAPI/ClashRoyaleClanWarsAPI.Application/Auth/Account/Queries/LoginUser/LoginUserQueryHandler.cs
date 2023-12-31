﻿using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using System.Security.Authentication;

namespace ClashRoyaleClanWarsAPI.Application.Auth.Account.Queries.LoginUser;

public class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, LoginResponse>
{
    private readonly IAccountRepository _repository;

    public LoginUserQueryHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LoginResponse>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        LoginResponse response;

        try
        {
            response = await _repository.LoginUserAsync(request.LoginModel);
        }
        catch (UsernameNotFoundException)
        {
            return Result.Failure<LoginResponse>(ErrorTypes.Auth.UsernameNotFound());
        }
        catch (InvalidPasswordException e)
        {
            return Result.Failure<LoginResponse>(ErrorTypes.Auth.InvalidPassword(e.Message));
        }
        catch (InvalidCredentialException)
        {
            return Result.Failure<LoginResponse>(ErrorTypes.Auth.InvalidCredentials());
        }
        

        return response;
    }
}
