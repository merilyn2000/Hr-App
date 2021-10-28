using Microsoft.AspNetCore.Identity;

namespace HrApp_WebAPI.Data.Entities.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
