using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiController(ISender sender)
    {
        _sender = sender;
    }

    protected IActionResult Problem(Error[] errors)
    {
        var firstError = errors[0];

        return Problem(firstError);
    }

    protected IActionResult Problem(Error error)
    {

        if (error == ErrorCode.IdNotFound ||
            error == ErrorCode.ModelNotFound ||
            error == ErrorCode.UsernameNotFound)
            return NotFound(error.Description);

        if (error == ErrorCode.IdsNotMatch ||
            error == ErrorCode.InvalidCredentials ||
            error == ErrorCode.InvalidPassword ||
            error == IValidationResult.ValidationError ||
            error == ErrorCode.ChallengeClosed ||
            error == ErrorCode.PlayerNotHaveCard)
            return BadRequest(error.Description);

        if (error == ErrorCode.DuplicateId ||
            error == ErrorCode.DuplicateUsername)
            return Conflict(error.Description);


        return Problem();
    }
}
