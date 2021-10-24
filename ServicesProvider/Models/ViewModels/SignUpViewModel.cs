using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesProvider.Models.ViewModels
{
    public class SignUpViewModel
    {
        //4-20 
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 4)]
        public string UserName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match.")]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }
    }
}
