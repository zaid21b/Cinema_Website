using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cinema_Website.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNetCore.Identity;
using CinemaWebsite2.Models;

namespace Cinema_Website.Data
{
    public class ApplicationDbContext : IdentityDbContext<CinemaWebsiteUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cinema_Website.Models.Movie> tblMovies { get; set; }
        public DbSet<Cinema_Website.Models.Category> tblCategories { get; set; }
        public DbSet<Cinema_Website.Models.AddingCategory> tblAddingCategories { get; set; }
        public DbSet<Cinema_Website.Models.Event> tblEvents { get; set; }
        public DbSet<Cinema_Website.Models.Hall> tblHalls { get; set; }
        public DbSet<Cinema_Website.Models.Ticket> tblTickets { get; set; }
        public DbSet<Cinema_Website.Models.OrdersCart> tblOrders { get; set; }
        public DbSet<Cinema_Website.Models.OrderTicket> tblOrderTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<CinemaWebsiteUser>()
                .HasOne(b => b.OrdersCart)
                .WithOne(i => i.CinemaWebsiteUser)
                .HasForeignKey<OrdersCart>(b => b.UserId);

            
            
        
   
        }


    }
}
