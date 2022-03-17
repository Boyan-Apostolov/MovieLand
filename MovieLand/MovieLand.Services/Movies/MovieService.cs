using System.Collections.Generic;
using MovieLand.Data.Models;
using MovieLand.Data;
using System.Linq;
using MovieLand.Services.DTOs;

namespace MovieLand.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MovieLandDbContext dbContext;

        public MovieService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreateMovie(CreateMovieDTO movieToCreate)
        {
            var movie = new Movie()
            {
                Title = movieToCreate.Title,
                Plot = movieToCreate.Plot,
                Producer = movieToCreate.Plot,
                Genre = movieToCreate.Genre,
                Actors = movieToCreate.Actors,
                KeyWords = movieToCreate.Keywords
            };

            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();
            return movie.Id;
        }

        public Movie? GetMovie(int id)
        {
            return this.dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetNumberOfMovies(int countToSkip, int countToTake)
        {
            return this.dbContext.Movies.Skip(countToSkip).Take(countToTake).ToList();
        }

        public List<Movie> SearchMovies(string title)
        {
            return this.dbContext.Movies.Where(x => x.Title.Contains(title)).ToList();
        }

        public bool DeleteMovie(int id)
        {
            var movie = this.dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie != null)
            {
                this.dbContext.Movies.Remove(movie);
                this.dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
