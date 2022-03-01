using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;

namespace MovieLand.Services.Movies
{
    public interface IMovieService
    {
        public void CreateMovie(int id, string title, string plot, string producer, string genre, string actors, ICollection<string> keyWords);
        public Movie? GetMovie(int id);

        public bool DeleteMovie(int id);

        public List<Movie> GetNumberOfMovies(int countToSkip, int countToTake);
    }
}
