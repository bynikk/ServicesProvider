using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext()
        {
                        
        }
        
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
         {
             Database.EnsureCreated();
         }
        

        public DbSet<UsersAd> UsersAds { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>();
            builder.Entity<UsersAd>();

            base.OnModelCreating(builder);
        }
    }
}
