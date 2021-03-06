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
        public enum TicketTypes
        {
            [Display(Name = "cool plus")]
            coolplus,
            [Display(Name = "cool")]
            cool,

        }

        [Key]
        public int TicketId { get; set; }
        [Display(Name ="Ticket Price")]
        public double TicketPrice { get; set; }
        public bool IsSelected { get; set; }
        public bool IsSold { get; set; }
        [Display(Name = "Ticket Type")]
        [Required(ErrorMessage = "The Ticket Type Is Required")]
        public TicketTypes TicketType { get; set; }
        public int SeatNumber { get; set; }
        //FK

        public int EventId { get; set; }
        //Navigation
        public ICollection<OrderTicket> OrderTickets { get; set; }
        public Event Event { get; set; }
    }
}
