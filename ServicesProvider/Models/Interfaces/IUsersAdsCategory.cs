using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Models.Interfaces
{
    public interface IUsersAdsCategory
    {
        IEnumerable<Category> AllCategories { get; }

        public List<SelectListItem> GetSelectListItems { get; }

        public string GetCategoryNameById(int id);

        public List<SelectListItem> UbdateSelectList(List<SelectListItem> selectListItems);
    }
}
