using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cinema_Website.Models;

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
    }
}
