using System.Collections.Generic;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Models.Interfaces
{
    public interface IUsersAdsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
