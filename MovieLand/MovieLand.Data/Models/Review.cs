using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLand.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [Range(1, 10)]
        public double Grade { get; set; }
        
        [Required]
        public string ReviewText { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
