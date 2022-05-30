using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Hall
    {
        [Key]
        public int HadllId { get; set; }
        [Display(Name = "Hall Number")]
        public int HallNumber { get; set; }

        //Navigation
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
