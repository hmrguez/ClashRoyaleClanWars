using ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.ChangePassword;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.DeleteUser;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.UpdateRole;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserById;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserByName;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/users")]
public class UserController : ApiController
{
    public UserController(ISender sender) : base(sender) { }

    // GET: api/users
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUserQuery();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/users/username/{username}
    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var query = new GetUserByNameQuery(username);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/users/{id:guid}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var query = new GetUserByIdQuery(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // DELETE api/users/{id:guid}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand(id);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PUT api/users/{id:guid}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleEnum role)
    {
        var command = new UpdateRoleCommand(id, UserRoles.MapRole(role));

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PUT api/users/{id:guid}/password
    [HttpPut("{id:guid}/password")]
    public async Task<IActionResult> ChangePassword(Guid id, [FromBody] string password)
    {
        var command = new ChangePasswordCommand(id, password);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
