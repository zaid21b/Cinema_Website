using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Website.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        //Navigation
        public AddingCategory AddingCategory { get; set; }
    }
}
