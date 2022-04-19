using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [DataType(DataType.DateTime,ErrorMessage ="Invalid DateTime")]
        public DateTime EventDateTime { get; set; }

        //FK
        public int HallId { get; set; }
        public int MovieId { get; set; }

        //Navigation
        public Hall Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Movie Movie { get; set; }
    }
}
