using System.ComponentModel.DataAnnotations;

namespace ManufacturingERP.Models
{
    public class LoginViewModel2
    {
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
