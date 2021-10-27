using HrApp_WebAPI.DTOs;
using HrApp_WebAPI.Entities;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<User> manager, ITokenService tokenService)
        {
            _userManager = manager;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<User>> UserRegister(UserRegisterDto userRegisterDto)
        {
            var user = await _userManager.FindByNameAsync(userRegisterDto.UserName);
            if (user != null)
            {
                throw new Exception("This user already exist!");
            }

            var newUser = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                PhoneNumber = userRegisterDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User registration fails!");
            }

            await _userManager.AddToRolesAsync(newUser, userRegisterDto.Roles);

            return newUser;
        }

        public async Task<ActionResult<LoggedInUser>> UserLogin(UserLoginDto userLoginDto)
        {
            var token = await _tokenService.CreateToken(userLoginDto);

            if (string.IsNullOrEmpty(token))
                throw new Exception("Wrong username or password!");

            return new LoggedInUser
            {
                Username = userLoginDto.UserName,
                Token = token,
            };
        }
    }
}
