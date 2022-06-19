using Cinema_Website.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebsite2.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<CinemaWebsiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Roles.Customer.ToString()));
        }
        public static async Task SeedAdminAsync(UserManager<CinemaWebsiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new CinemaWebsiteUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "hadi",
                LastName = "bassam",
                PhoneNumber = "0795884392",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin123@");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Roles.Admin.ToString());
                }

            }
        }
    }
}
