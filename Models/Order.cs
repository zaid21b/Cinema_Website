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
        [Display(Name ="Number Of Tickets")]
        [Range(minimum:0,maximum:30,ErrorMessage ="The Number of Tickets should be more than 0"),]
        public int NumOfTickets { get; set; } = 0;
        //FK
        public int CustomerId { get; set; }

        //Navigation
        public Customer Customer { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
