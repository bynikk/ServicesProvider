using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.ViewModels;

namespace ServicesProvider.Data.DbObjects
{
    public class DbUsersAdManager
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public DbUsersAdManager(ApplicationDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public bool AddUserAd(UsersAdViewModel model, ApplicationUser user)
        {
            try
            {
                UsersAd UsersAd = new() { };
                UsersAd.Name = model.Name;
                UsersAd.LongDesc = model.LongDesc;
                UsersAd.ShortDesc = model.ShortDesc;
                UsersAd.Price = Convert.ToUInt16(model.Price);
                UsersAd.CategoryId = model.CategoryId;
                UsersAd.OwnerUsername = user.UserName;
                UsersAd.Category = FindCategoryByCategoryId(model.CategoryId);

                // Save image to wwwroot/ImagesAds
                string wwwrootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yy_mm_ss_fff") + extension;
                UsersAd.ImageName = fileName;
                string path = Path.Combine(wwwrootPath + "/ImagesAds/", fileName);

                UsersAd.ImagePath = path;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyToAsync(fileStream);
                }
                //
                _context.AddAsync(UsersAd);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add ex: {ex}");
                return false;
            }
        }

        public Category FindCategoryByCategoryId(int CategoryId)
        {
            return _context.Category.FirstAsync(x => x.Id == CategoryId).GetAwaiter()
                .GetResult(); ;
        }
    }
}
