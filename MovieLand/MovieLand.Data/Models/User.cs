using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLand.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public List<Movie> WatchedMovies { get; set; }

        public List<Review> Reviews { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
