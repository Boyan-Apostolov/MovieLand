using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MovieLand.Common;
using Newtonsoft.Json;
using MovieLand.Data;
using MovieLand.Data.Models;
using MovieLand.Services.DTOs;

namespace MovieLand.Services.SeederService
{
    public class SeederService : ISeederService
    {
        private MovieLandDbContext dbContext;

        public SeederService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int SeedMovies(int fromCount, int toCount)
        {
            string top250MoviesJson = new WebClient().DownloadString(GlobalConstants.Top250MoviesEndpoint);

            var results = JsonConvert.DeserializeObject<Top250MoviesDTO>(top250MoviesJson);

            for (int i = fromCount; i <= toCount; i++)
            {
                var movieJson = new WebClient()
                    .DownloadString(
                        string.Format(GlobalConstants.MovieInfoEndpoint, results.Items[i].Id));

                var movieToAdd =JsonConvert.DeserializeObject<MoviesDowloaderDTO>(movieJson);

                dbContext.Movies.Add(new Movie()
                {
                    Title = movieToAdd.Title,
                    Actors = movieToAdd.Stars,
                    Genre = movieToAdd.Genres,
                    KeyWords = movieToAdd.KeyWordList.ToList(),
                    Plot = movieToAdd.Plot,
                    Producer = movieToAdd.Directors
                });
            }

            return dbContext.SaveChanges();
        }
    }
}
