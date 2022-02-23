using System;
using Microsoft.EntityFrameworkCore;

using MovieLand.Data;
using MovieLand.Common;
using MovieLand.Services.ControllerService;
using MovieLand.Services.PrinterService;
using MovieLand.Services.MovieService;
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

            var controller = new ControllerService(dbContext);
            controller.Run();
        }
    }
}
