using Cinema_Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public double TicketPrice { get; set; }
        public bool IsSelected { get; set; }
        //FK

        public int EventId { get; set; }
        //Navigation
        public ICollection<OrderTicket> OrderTickets { get; set; }
        public Event Event { get; set; }
    }
}
