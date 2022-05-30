using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cinema_Website.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CinemaWebsite2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cinema_Website.Models.Customer> tblCustomers { get; set; }
        public DbSet<Cinema_Website.Models.Movie> tblMovies { get; set; }
        public DbSet<Cinema_Website.Models.Admin> tblAdmins { get; set; }
        public DbSet<Cinema_Website.Models.Category> tblCategories { get; set; }
        public DbSet<Cinema_Website.Models.AddingCategory> tblAddingCategories { get; set; }
        public DbSet<Cinema_Website.Models.Event> tblEvents { get; set; }
        public DbSet<Cinema_Website.Models.Hall> tblHalls { get; set; }
        public DbSet<Cinema_Website.Models.Seat> tblSeats { get; set; }
        public DbSet<Cinema_Website.Models.Ticket> tblTickets { get; set; }
        public DbSet<Cinema_Website.Models.Order> tblOrders { get; set; }

        

    }
}
