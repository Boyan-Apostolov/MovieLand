using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;

namespace MovieLand.Services.MovieService
{
    public interface IMovieService
    {
        public void CreateMovie(string title, string plot, string producer, string genre);

        public Movie? GetMovie(int id);

        public void DeleteMovie(int id);
    }
}
