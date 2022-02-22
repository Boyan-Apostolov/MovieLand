using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;
using MovieLand.Data;
using System.Linq;

namespace MovieLand.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly MovieLandDbContext dbContext;

        public MovieService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateMovie( string title, string plot, string producer, string genre)
        {
            var movie = new Movie()
            {
                Title = title,
                Plot= plot,
                Producer=producer,
                Genre=genre
            };
            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();
        }

        public Movie? GetMovie(int id)
        {
            var movie = new Movie()
            {
                Id = id
            };

            if (this.dbContext.Movies.Any(m => m.Id == id))
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = new Movie()
            {
                Id=id
            };
            if (this.dbContext.Movies.Any(m => m.Id == id))
            {
                this.dbContext.Movies.Remove(movie);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}
