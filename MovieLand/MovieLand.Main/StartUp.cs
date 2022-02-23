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
        }
    }
}
