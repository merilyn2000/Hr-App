using HrApp_WebAPI.Entities;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<User> _userManager;

        public AdministratorService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddRole(User user, IEnumerable<string> role)
        {
            return await _userManager.AddToRolesAsync(user, role);
        }

        public async Task<IdentityResult> RemoveRole(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return await _userManager.RemoveFromRolesAsync(user, role);
        }
    }
}
