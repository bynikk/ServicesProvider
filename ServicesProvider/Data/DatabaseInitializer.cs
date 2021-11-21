using System.Collections.Generic;
using System.Linq;
using ServicesProvider.Models;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Data
{
    public static class DatabaseInitializer
    {
        public static void Initial(ApplicationDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.AddRange(new Category[]
                    {
                        new Category() {CategoryName = "Web Development", Description = "Web develpment services."},
                        new Category() {CategoryName = "Game Development", Description = "Game develpment services."},
                        new Category() {CategoryName = "Design", Description = "Design services.."},
                        new Category() {CategoryName = "Mobile Development", Description = "Mobile develpment services."}
                    });
            }

            context.SaveChanges();
        }
    }
}
