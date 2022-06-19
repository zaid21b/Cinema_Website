using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class OrdersCart
    {
        [Key]
        public int OrederId { get; set; }
        //FK
        public string UserId { get; set; }
        //Navigation
        public ICollection<OrderTicket> OrderTickets { get; set; }
        public CinemaWebsiteUser CinemaWebsiteUser { get; set; }
    }
}
