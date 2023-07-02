using System;
using System.ComponentModel.DataAnnotations;

namespace TekGain.DAL.Entities
{
    public class SignIn
    {
        // Implement the properties here
        [Required]
        [EmailAddress(ErrorMessage = "Valid Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
