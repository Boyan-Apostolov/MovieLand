using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using MovieLand.Common;
using MovieLand.Data;
using MovieLand.Data.Models;
using MovieLand.Services.MovieService;
using MovieLand.Services.PrinterService;
using MovieLand.Services.SeederService;
using MovieLand.Services.UserService;

namespace MovieLand.Main
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ConfigureConsole();
            Run();
        }

        public static void ConfigureConsole()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WindowWidth = 120;
        }

        public static void Run()
        {
            var dbContext = new MovieLandDbContext();
            dbContext.Database.Migrate();

            var seederService = new SeederService(dbContext);
            //seederService.SeedMovies(1, 10);

            var movieService = new MovieService(dbContext);

            var printerService = new PrinterService(movieService);

            printerService.ShowWelcomeMessage();
            printerService.PrintNumberOfMovies(0, GlobalConstants.PrinterConfigs.DefaultNumberOfShownMovies);
        }
    }
}
