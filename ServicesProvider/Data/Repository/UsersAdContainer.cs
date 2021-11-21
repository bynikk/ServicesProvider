using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.Interfaces;

namespace ServicesProvider.Data.Repository
{
    public class UsersAdContainer : IAllUsersAds
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsersAdContainer(
            ApplicationDbContext applicationDbContext
            )
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<UsersAd> UsersAds => _applicationDbContext.UsersAds.Include(x => x.Category);

        public UsersAd GetUserAd(int userAdId) => _applicationDbContext.UsersAds.FirstOrDefault(x => x.Id == userAdId);

        public List<UsersAd> GetUsersAdsByCategoryId(int categoryId)
        {
            List<UsersAd> usersAds = UsersAds.ToList();

            if (categoryId != -1)
            {
                usersAds = UsersAds.Where(x => x.CategoryId == categoryId).ToList();
            }
            return usersAds;
        }

        //public PartialViewResult GetUsersAdsByCategoryId(int categoryId = -1)
        //{
        //    IEnumerable<UsersAd> usersAds = _applicationDbContext.UsersAds;

        //    if (categoryId != -1)
        //    {
        //        usersAds = _applicationDbContext.UsersAds.Where(x => x.CategoryId == categoryId);
        //    }
        //    return PartialViewResult { UsersAds = usersAds,};
        //}
    }
}
