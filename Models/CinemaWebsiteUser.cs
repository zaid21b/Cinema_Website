using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class CinemaWebsiteUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "please enter your first name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "please enter your last name")]
        public string LastName { get; set; }
        //Navigation
        public OrdersCart OrdersCart { get; set; }
    }
}
