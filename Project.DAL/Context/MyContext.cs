using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using Project.MAP.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext: IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfigurations());
            builder.ApplyConfiguration(new CategoryConfigurations());
            builder.ApplyConfiguration(new OrderConfigurations());
            builder.ApplyConfiguration(new OrderDetailConfigurations());
            builder.ApplyConfiguration(new ProfileConfigurations());
            builder.ApplyConfiguration(new ProductConfigurations());
            base.OnModelCreating(builder);
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }
    }
}
