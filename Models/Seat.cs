using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        public SeatType SeatType { get; set; }
        public ScreenType Screen { get; set; }

        //FK
        public int TicketId { get; set; }
        public int HallId { get; set; }

        //Navigation
        public Ticket Ticket { get; set; }
        public Hall Hall { get; set; }
    }
}
