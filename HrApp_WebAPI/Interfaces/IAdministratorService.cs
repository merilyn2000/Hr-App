using HrApp_WebAPI.Data.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Interfaces
{
    interface IAdministratorService
    {
        Task<IdentityResult> AddRole(User user, IEnumerable<string> role);
        Task<IdentityResult> RemoveRole(User user);
    }
}
