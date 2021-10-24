using Microsoft.AspNetCore.Identity;
using System;

namespace ServicesProvider.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }
    }
}