using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class OrderTicket
    {
        [Key]
        public int OrderTicketId { get; set; }
        //FK
        public int TicketId { get; set; }
        public int OrderId { get; set; }

        //Navigation
        public Ticket Ticket { get; set; }
        public OrdersCart Order { get; set; }
    }
}
