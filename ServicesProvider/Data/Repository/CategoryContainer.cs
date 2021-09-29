using System.Collections.Generic;
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
    }
}
