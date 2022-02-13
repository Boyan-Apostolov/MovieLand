using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;

namespace MovieLand.Services.DTOs
{
    public class MoviesDowloaderDTO
    {
        public string Title { get; set; }

        public string Plot { get; set; }

        public string Directors { get; set; }

        public string Genres { get; set; }

        public string Stars { get; set; }

        public string[] KeyWordList;
    }
}
