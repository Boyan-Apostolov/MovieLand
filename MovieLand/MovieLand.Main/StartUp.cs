using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieLand.Data;
using MovieLand.Services.SeederService;

namespace MovieLand.Main
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new MovieLandDbContext();
            dbContext.Database.Migrate();
            
            var seederService = new SeederService(dbContext);
            var addedMovies = seederService.SeedMovies(0,5);

            Console.WriteLine($"Added: {addedMovies} movies");
        }
    }
}
