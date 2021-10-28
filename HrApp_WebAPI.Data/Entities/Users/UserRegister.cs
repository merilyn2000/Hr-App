﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrApp_WebAPI.Data.Entities.Users
{
    public class UserRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
