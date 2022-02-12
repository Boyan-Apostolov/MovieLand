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

        private double grade;

        [Required]
        public double Grade
        {
            get { return grade; }
            set {
                    if (value <=10)
                    {
                        grade = value;
                    }
                }
        }
        [Required]
        public string ReviewText { get; set; }

    }
}
