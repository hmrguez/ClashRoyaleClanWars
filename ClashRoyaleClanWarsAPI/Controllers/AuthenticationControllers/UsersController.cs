using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        // POST api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserModel user)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _userService.RegisterUserAsync(user);

            if(!result.Success) 
                return BadRequest(new {result.Message, result.Errors});

            return Created($"api/user/{user.Username}", result.Data);

        }

        // GET api/user/{username}
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            User user = null!;

            try
            {
                user = await _userService.GetUserAsync(username);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(new UserManagerResponse(success: false, message: e.Message));
            }

            return Ok(user);
        }

        // POST api/user/login
        [HttpPost("login")]
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

            return Ok(response);
        }
    }
}
