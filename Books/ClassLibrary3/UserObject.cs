using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class UserObject
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email ID")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(pattern: @"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must be at least 6 characters and contains at least one special character, number and Upper case character")]
        public string Password { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; }
    }
}
