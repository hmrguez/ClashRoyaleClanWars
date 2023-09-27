using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.AuthenticationControllers
{
    [Route("api/auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        // POST api/auth/register/user
        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser(RegisterModel user)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _userService.RegisterUserAsync(user);

            if(!result.Success) 
                return BadRequest(result);

            return Created($"api/user/{user.Username}", result.Data);

        }

        // GET api/auth/{username}
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            User user;

            try
            {
                user = await _userService.GetUserAsync(username);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(new RequestResponse<User>(success: false, message: e.Message));
            }

            return Ok(user);
        }

        // POST api/auth/login/user
        [HttpPost("login/user")]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            LoginResponse response;
            try
            {
                response = await _userService.LoginUserAsync(loginUser);

            }
            catch (UserNotFoundException e)
            {
                return NotFound(new RequestResponse<LoginUserModel>(loginUser, e.Message, false));
            }
            catch (InvalidPasswordException e)
            {
                return BadRequest(new RequestResponse<LoginUserModel>(loginUser, e.Message, false));
            }

            return Ok(new RequestResponse<LoginResponse>(response, success:true));
        }

        // POST api/auth/register/admin
        [Authorize(Roles =UserRoles.SUPERADMIN)]
        [Authorize(Roles =UserRoles.ADMIN)]
        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterAdminAsync(model);

            if (!result.Success)
                return BadRequest(result);

            return Created($"api/auth/{model.Username}", result.Data);

        }
    }
}
