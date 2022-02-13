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

        public User CreatedBy { get; set; }

        [Required]
        [Range(1, 10)]
        public double Grade { get; set; }
        
        [Required]
        public string ReviewText { get; set; }

    }
}
