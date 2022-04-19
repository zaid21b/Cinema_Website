using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Order
    {
        [Key]
        public int OrederId { get; set; }

        //FK
        public int CustomerId { get; set; }

        //Navigation
        public Customer Customer { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
