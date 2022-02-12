using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLand.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Plot { get; set; }

        [Required]
        public string Producer { get; set; }

        public List<Review> Review { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public List<string> Actors{get; set; }

        [Required]
        public List<string> KeyWords { get; set; }
        
    }
}
