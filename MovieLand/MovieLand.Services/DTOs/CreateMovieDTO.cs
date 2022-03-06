using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }

        public string Plot { get; set; }

        public string Producer { get; set; }

        public string Genre { get; set; }

        public string Actors { get; set; }

        public ICollection<string> Keywords { get; set; }
    }
}
