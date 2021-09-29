using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Models
{
    public class UsersAdHomeViewModel
    {
        public IEnumerable<UsersAd> allUsersAds { get; set; }

        public int curCategory { get; set; }

        public string categoryViewName { get; set; }
    }
}
