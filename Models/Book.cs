using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, ErrorMessage = "The maximum size of {0} must be at least {2} and maximum {1} characters", MinimumLength = 3)]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, ErrorMessage = "The maximum size of {0} must be at least {2} and maximum {1} characters", MinimumLength = 3)]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, ErrorMessage = "The maximum size of {0} must be at least {2} and maximum {1} characters", MinimumLength = 3)]
        [Display(Name = "Author")]
        public string author { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime dateRelease { get; set; }
        [Required(ErrorMessage = "The {0} is required")]
        public int price { get; set; }

    }
}
