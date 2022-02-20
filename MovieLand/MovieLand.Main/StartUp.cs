using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using MovieLand.Data;
using MovieLand.Data.Models;
using MovieLand.Services.SeederService;
using MovieLand.Services.UserService;

namespace MovieLand.Main
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new MovieLandDbContext();
            dbContext.Database.Migrate();
            
            var movie = dbContext.Movies.First(x => x.Id == 1);

            //var review = new Review()
            //{
            //    CreatedBy = dbContext.Users.First(),
            //    CreatedOn = DateTime.Now,
            //    Grade = 6,
            //    ReviewText = "ok",
            //    MovieId = movie.Id
            //};

            //dbContext.Reviews.Add(review);

            //dbContext.SaveChanges();

            Console.WriteLine(dbContext.Reviews.Count(x => x.MovieId == movie.Id)); //1

            //var seederService = new SeederService(dbContext);
            //var addedMovies = seederService.SeedMovies(50, 10);
            //Console.WriteLine($"Added: {addedMovies} movies");

            //var userService = new UserService(dbContext);

            //Console.Write("Register/Login?[R/L]   ");
            //var command = Console.ReadLine();

            //Console.Write("Username:   ");
            //var username = Console.ReadLine();

            //Console.Write("Password:   ");
            //var password = Console.ReadLine();

            //var result = "";

            //if (command == "R")
            //{
            //    Console.Write("Email:   ");
            //    var email = Console.ReadLine();

            //    result = userService.Register(email, username, password) 
            //        ? "Register successful!" 
            //        : "Invalid data!";
            //}
            //else
            //{
            //    result = userService.Login(username, password) 
            //        ? "Login successful!" 
            //        : "Invalid data!";
            //}

            //Console.WriteLine(result);
        }
    }
}
