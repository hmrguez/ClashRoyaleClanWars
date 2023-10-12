using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.AuthenticationControllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<IdentityUser>? users = null;
            try
            {
                users = await _userService.GetAllAsync();
            }
            catch (ModelNotFoundException<IdentityUser> e)
            {
                return NotFound(new RequestResponse<IdentityUser>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<IdentityUser>>(users!));

        }

        // GET api/users/username/{username}
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            User user;

            try
            {
                user = await _userService.GetUserByNameAsync(username);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(new RequestResponse<User>(success: false, message: e.Message));
            }

            return Ok(user);
        }

        // GET api/users/{id:string}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            User user;

            try
            {
                user = await _userService.GetUserByIdAsync(id);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(new RequestResponse<User>(success: false, message: e.Message));
            }

            return Ok(user);
        }

        // DELETE api/users/{id:string}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _userService.Delete(id);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

    }
}
