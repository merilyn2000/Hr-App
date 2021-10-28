using HrApp_WebAPI.Data.Entities.Users;
using HrApp_WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Interfaces
{
    public interface IAccountService
    {
        public Task<ActionResult<User>> UserRegister(UserRegisterDto userRegisterDto);
        public Task<ActionResult<LoggedInUser>> UserLogin(UserLoginDto userLoginDto);

    }
}
