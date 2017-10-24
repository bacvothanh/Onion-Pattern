using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class RegisterBindingModel : BaseBindingModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string TimeZoneId { get; set; }
        public ReadOnlyCollection<TimeZoneInfo> TimeZoneList { get; set; }
        public string ReturnUrl { get; set; }
        
    }

    public class LoginBindingModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class ResetPasswordBindingModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    public class ForgetPasswordBindingModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "The username is not valid")]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Current Password")]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        [DisplayName("Re-type New Password")]
        public string CofirmNewPassword { get; set; }
    }
    public class AccountViewModel
    {
        public long Id { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address!")]
        public string Email { get; set; }
        [MaxLength(20), Phone(ErrorMessage = "Not a valid Phone number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime? TimeLastLoginOnUtc { get; set; }
        public DateTime? TimeCreateOnUtc { get; set; }
    }
}
