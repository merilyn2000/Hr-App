using HrApp_WebAPI.Data.Entities.Users;
using HrApp_WebAPI.DTOs;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService; 

        public AccountController(IAccountService accountService)
        {
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