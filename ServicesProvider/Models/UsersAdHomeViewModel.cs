using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Models
{
    public class UsersAdHomeViewModel
    {
        public IEnumerable<UsersAd> allUsersAds { get; set; }

        public List<SelectListItem> SelectList { get; set; }

        public int curCategoryId { get; set; }

        public string categoryViewName { get; set; }


    }
}
