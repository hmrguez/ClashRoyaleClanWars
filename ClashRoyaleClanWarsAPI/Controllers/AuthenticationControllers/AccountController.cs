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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        // POST api/account/register/user
        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser(RegisterModel user)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _accountService.RegisterUserAsync(user);

            if(!result.Success) 
                return BadRequest(result);

            return Created($"api/user/{user.Username}", result.Data);

        }

        // POST api/account/login/user
        [HttpPost("login/user")]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            LoginResponse response;
            try
            {
                response = await _accountService.LoginUserAsync(loginUser);

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

        // POST api/account/register/admin
        [Authorize(Roles =UserRoles.SUPERADMIN)]
        [Authorize(Roles =UserRoles.ADMIN)]
        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.RegisterAdminAsync(model);

            if (!result.Success)
                return BadRequest(result);

            return Created($"api/auth/{model.Username}", result.Data);

        }
    }
}
