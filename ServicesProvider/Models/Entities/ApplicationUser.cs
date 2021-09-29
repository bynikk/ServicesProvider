using System;
using Microsoft.AspNetCore.Identity;

namespace ServicesProvider.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
