using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.Interfaces;

namespace ServicesProvider.Data.Repository
{
    public class CategoryContainer : IUsersAdsCategory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryContainer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> AllCategories => _applicationDbContext.Category;

        public List<SelectListItem> GetSelectListItems => _applicationDbContext.Category.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.CategoryName
                                  }).ToList();

        public string GetCategoryNameById(int id)
        {
            string resultString = "All categories";
            if (id != -1)
            {
                resultString = _applicationDbContext.Category.FirstOrDefault(x => x.Id == id).CategoryName;
            }

            return resultString;
        }

        public List<SelectListItem> UbdateSelectList(List<SelectListItem> selectListItems)
        {
            if (!selectListItems.Equals(GetSelectListItems))
            {
                selectListItems = GetSelectListItems;
            }

            return selectListItems;
        }
    }
}
