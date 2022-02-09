using System;
using Microsoft.EntityFrameworkCore;
using MovieLand.Data;

namespace MovieLand.Main
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //TODO: move to service
            var dbContext = new MovieLandDbContext();
            dbContext.Database.Migrate();
        }
    }
}
