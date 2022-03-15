using System;
using Autofac;
using Microsoft.EntityFrameworkCore;

using MovieLand.Data;
using MovieLand.Main.Autofac;

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
            // autofac
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<Controller>();

                app.Run();
            }
        }
    }
}
