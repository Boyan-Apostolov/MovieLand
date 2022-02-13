using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLand.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new List<string>();
            this.KeyWords = new List<string>();
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Plot { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public string Genre { get; set; }

        public List<string> Actors;

        public List<string> KeyWords;

        public List<Review> Reviews;
    }
}
