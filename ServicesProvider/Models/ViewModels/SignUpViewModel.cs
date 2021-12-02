using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesProvider.Models.ViewModels
{
    public class SignUpViewModel
    {
        //4-20 
        [Required]
        [RegularExpression(@"^\w+$")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match.")]
        public string PasswordConfirm { get; set; }

        [Required]
        [RegularExpression(@"^\+?(\d[\d -. ]+)?(\([\d -. ]+\))?[\d-. ]+\d$")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, MinimumLength = 13)]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }
    }
}
