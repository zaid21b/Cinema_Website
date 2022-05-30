using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Seat
    {
        public enum SeatType
        {
            Cool,
            CoolPlus
        }

        public enum ScreenType
        {
            _2D,
            _3D
        }

        [Key]
        public int SeatId { get; set; }
        [Display(Name ="Seat Type")]
        public SeatType SeatT { get; set; } = SeatType.Cool;
        public ScreenType Screen { get; set; } = ScreenType._2D;

        //FK
       
        public int HallId { get; set; }

        //Navigation
        
        public Hall Hall { get; set; }
    }
}
