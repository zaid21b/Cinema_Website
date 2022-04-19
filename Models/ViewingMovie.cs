using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class ViewingMovie
    {
        public int ViewingMovieId { get; set; }

        //FK
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

        //Navigation
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
