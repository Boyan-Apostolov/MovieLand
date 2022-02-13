using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.DTOs
{
    public class Top250MoviesDTO
    {
        public Top250MoviePartDTO[] Items { get; set; }
    }

    public class Top250MoviePartDTO
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
    }
}
