using System;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Models.ViewModels;

namespace ServicesProvider.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(SignUpViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            UserName = model.UserName;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;
            PasswordHash = model.Password;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
