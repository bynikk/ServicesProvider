using System.Collections.Generic;
using System.Linq;
using ServicesProvider.Models;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Data
{
    public static class DatabaseInitializer1
    {
        //temp
        private static string imgUrl = "https://shwanoff.ru/wp-content/uploads/2018/05/programming.jpg";
        private static string uraUrl = "https://sun9-68.userapi.com/s/v1/ig2/fCY99egStyyX8UFtLazVeajNSS9CsiyP0ALmdncdF7hsRHNnli2Lv_BqBU_YNLhueuzh_hOsKZYSNTgVugjwfXcf.jpg?size=200x214&quality=95&crop=101,86,454,488&ava=1";
        public static void Initial(ApplicationDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(x => x.Value));
            }

            if (!context.UsersAds.Any())
            {
                context.AddRange(
                    new UsersAd()
                    {
                        Name = "BackEnd ASP.NET", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 190,
                        Category = Categories[CategoryNames.Programming]
                    },
                    new UsersAd()
                    {
                        Name = "Site Design", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 283,
                        Category = Categories[CategoryNames.Design]
                    },
                    new UsersAd()
                    {
                        Name = "Site Design", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 373,
                        Category = Categories[CategoryNames.Design]
                    },
                    new UsersAd()
                    {
                        Name = "Site Design", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 464,
                        Category = Categories[CategoryNames.Design]
                    },
                    new UsersAd()
                    {
                        Name = "Site Design", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 464,
                        Category = Categories[CategoryNames.Design]
                    },
                    new UsersAd()
                    {
                        Name = "JS Dev", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 464,
                        Category = Categories[CategoryNames.Programming]
                    },
                    new UsersAd()
                    {
                        Name = "C++ Dev", LongDesc = "", ShortDesc = "", Img = imgUrl, Price = 464,
                        Category = Categories[CategoryNames.Programming]
                    },
                    new UsersAd()
                    {
                        Name = "csgo dev", LongDesc = "", ShortDesc = "", Img = uraUrl, Price = 1231,
                        Category = Categories[CategoryNames.Programming]
                    }
                );
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category() {CategoryName = "Programming", Description = "Writing code."},
                        new Category() {CategoryName = "Design", Description = "Design anything."}
                    };
                    category = new Dictionary<string, Category>();

                    foreach (var item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }   
                }

                return category;
            }
        }
    }
}
