using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public string MovieTrailer { get; set; }

        //FK
        

        //Navigation
        
        public ICollection<Event> Events { get; set; }
        public AddingCategory AddingCategory { get; set; }
    }
}
