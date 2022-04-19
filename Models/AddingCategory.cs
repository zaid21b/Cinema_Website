using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class AddingCategory
    {
        [Key]
        public int AddingCategoryId { get; set; }

        //FK
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        //Navigation
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
