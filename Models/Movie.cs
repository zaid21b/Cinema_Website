using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Movie
    {
        public enum MMPARatings
        {

            PG_9,
            PG_13,
            PG_18

        }



        [Key]
        public int MovieId { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "The Movie Name Is Required")]
        public string MovieName { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "The Movie Description Is Required")]
        public string MovieDescription { get; set; }
        [Display(Name = "Movie Image")]
        public string MovieImage { get; set; }
        [Display(Name = "Movie Trailer")]
        [Required(ErrorMessage = "The Movie Trailer Is Required")]
        public string MovieTrailer { get; set; }
        [Display(Name = "Movie Geners")]
        [Required(ErrorMessage = "The Movie Generes Is Required")]
        public String Generes { get; set; }
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "The Release Date Is Required")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Run Time")]
        [Required(ErrorMessage = "The Run Time Is Required")]
        public String RunTime { get; set; }
        [Display(Name = "MMMP Rating")]
        [Required(ErrorMessage = "The MMP Rating Is Required")]
        public MMPARatings MMPARating { get; set; }
        [Display(Name = "Movie Rating")]
        [Required(ErrorMessage = "The Movie Rating Is Required")]
        public Double MovieRating { get; set; }

        //FK

        //Navigation
        public ICollection<Event> Events { get; set; }
        public AddingCategory AddingCategory { get; set; }
    }
}
