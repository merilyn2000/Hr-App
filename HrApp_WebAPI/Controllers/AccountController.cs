using HrApp_WebAPI.DTOs;
using HrApp_WebAPI.Entities;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService; 

        public AccountController(UserManager<User> manager, ITokenService tokenService, IAccountService accountService)
        {
            _userManager = manager;
            _tokenService = tokenService;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> UserRegister(UserRegisterDto userRegisterDto)
        {

            return (await _accountService.UserRegister(userRegisterDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoggedInUser>> UserLogin(UserLoginDto userLoginDto)
        {
            return(await _accountService.UserLogin(userLoginDto));
        }
    }
}