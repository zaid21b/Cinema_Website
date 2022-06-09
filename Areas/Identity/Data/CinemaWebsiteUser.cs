﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Website.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaWebsite2.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CinemaWebsiteUser class
    public class CinemaWebsiteUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(30)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
       
    }
}
