using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;
using MovieLand.Services.DTOs;

namespace MovieLand.Services.Movies
{
    public interface IMovieService
    {
        public void CreateMovie(CreateMovieDTO movieToCreate);

        public Movie? GetMovie(int id);

        public bool DeleteMovie(int id);

        public List<Movie> GetNumberOfMovies(int countToSkip, int countToTake);

        public List<Movie> SearchMovies(string title);
    }
}
