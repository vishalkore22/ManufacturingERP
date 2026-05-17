using System.ComponentModel.DataAnnotations;

namespace ManufacturingERP.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email Is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password length at least 6 Character.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z]).+$", ErrorMessage = "Password must contain at least One Alfanumeric Character, One Uppercase letter ('A','Z'), One Lowercase letter ('a','z'), and One Number ('0','9').")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
