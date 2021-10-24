using Microsoft.AspNetCore.Identity;
using ServicesProvider.Models.Entities;
using System.Linq;

namespace ServicesProvider.Models
{
    public static class ProcessUserClaim
    {
        public static bool HasClaim(this UserManager<ApplicationUser> userManager, ApplicationUser user, string type, string value)
        {
            return userManager.GetClaimsAsync(user).GetAwaiter().GetResult().Any(c => c.Type == type && c.Value == value);
        }
    }
}
