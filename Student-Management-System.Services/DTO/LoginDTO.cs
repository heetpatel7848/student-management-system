﻿using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Services.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
