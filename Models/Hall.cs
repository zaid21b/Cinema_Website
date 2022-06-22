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
        [Range(maximum:10000000000000000,minimum:1,ErrorMessage ="The Hall Number Should Be Positive")]
        public int HallNumber { get; set; }

        //Navigation
        
        public ICollection<Event> Events { get; set; }
    }
}
