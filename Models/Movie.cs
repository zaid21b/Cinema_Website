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
        public byte[] MovieImage { get; set; }
        public string MovieTrailer { get; set; }

        //FK
        public int AdminId { get; set; }

        //Navigation
        public Admin Admin { get; set; }
        public ICollection<Event> Events { get; set; }
        public AddingCategory AddingCategory { get; set; }
        public ViewingMovie ViewingMovie { get; set; }
    }
}
