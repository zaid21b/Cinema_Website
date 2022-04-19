using System;
using CinemaWebsite2.Data;
using CinemaWebsite2.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CinemaWebsite2.Areas.Identity.IdentityHostingStartup))]
namespace CinemaWebsite2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CinemaWebsiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CinemaWebsiteContextConnection")));

                services.AddDefaultIdentity<CinemaWebsiteUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<CinemaWebsiteContext>();
            });
        }
    }
}