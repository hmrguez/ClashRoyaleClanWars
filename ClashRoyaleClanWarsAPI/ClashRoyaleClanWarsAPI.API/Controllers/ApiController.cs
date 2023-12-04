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
        if (errors.Length > 1)
            return BadRequest(string.Join(" ", errors.AsEnumerable()));

        return Problem(errors[0]);
    }

    protected IActionResult Problem(Error error)
    {

        if (error == ErrorCode.IdNotFound ||
            error == ErrorCode.ModelNotFound ||
            error == ErrorCode.UsernameNotFound ||
            error == ErrorCode.RoleNotFound)
            return NotFound(error.Description);

        if (error == ErrorCode.Validation ||
            error == ErrorCode.IdsNotMatch ||
            error == ErrorCode.InvalidCredentials ||
            error == ErrorCode.InvalidPassword ||
            error == ErrorCode.PasswordsNotMatch ||
            error == ErrorCode.ChallengeClosed ||
            error == ErrorCode.PlayerNotHaveCard ||
            error == ErrorCode.PlayerHasNoClan ||
            error == ErrorCode.PlayerHasNoEnoughTrophies ||
            error == ErrorCode.ClanFull ||
            error == ErrorCode.WarFull ||
            error == ErrorCode.PlayerHasNoEnoughLevel)
            return BadRequest(error.Description);

        if (error == ErrorCode.DuplicateId ||
            error == ErrorCode.DuplicateUsername ||
            error == ErrorCode.PlayerHasClan ||
            error == ErrorCode.ClanAlreadyInWar)
            return Conflict(error.Description);


        return Problem();
    }
}
