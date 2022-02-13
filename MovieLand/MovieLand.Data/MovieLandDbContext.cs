using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieLand.Data.Models;
using MySql.Data.MySqlClient;

namespace MovieLand.Data
{
    public class MovieLandDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            MySqlConnectionStringBuilder sqlConnectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "MovieLand",
                Port = 3306,
                UserID = "developer",
                Password = "password"
            };

            return sqlConnectionStringBuilder.ConnectionString;
        }

    }
}
