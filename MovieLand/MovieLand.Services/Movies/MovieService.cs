using System.Collections.Generic;
using MovieLand.Data.Models;
using MovieLand.Data;
using System.Linq;

namespace MovieLand.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MovieLandDbContext dbContext;

        public MovieService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateMovie(string title, string plot, string producer, string genre)
        {
            var movie = new Data.Models.Movie()
            {
                Title = title,
                Plot = plot,
                Producer = producer,
                Genre = genre
            };

            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();
        }

        public Movie? GetMovie(int id)
        {
            return this.dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetNumberOfMovies(int countToSkip, int countToTake)
        {
            return this.dbContext.Movies.Skip(countToSkip).Take(countToTake).ToList();
        }

        public bool DeleteMovie(int id)
        {
            var movie = this.dbContext.Movies.FirstOrDefault(x => x.Id == id); ;

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
