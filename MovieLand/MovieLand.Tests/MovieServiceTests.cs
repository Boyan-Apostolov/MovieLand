using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLand.Data.Models;
using MovieLand.Services.DTOs;
using NUnit.Framework;

namespace MovieLand.Tests
{
    public class MovieServiceTests : BaseTestClass
    {
        
        public void RemoveMovie()
        {
            var abmovie = this.dbContext.Movies.First(x => x.Title == "TTest");
            this.dbContext.Movies.Remove(abmovie);
            this.dbContext.SaveChanges();
        }

        static readonly CreateMovieDTO data10 = new CreateMovieDTO()
        {
            Actors = "Test",
            Genre = "Ganre1",
            Keywords = new List<string>
                {
                  "Test1","Test2","Test3","rado",
                },
            Plot = "Plto01",
            Producer = "T.Test",
            Title = "TTest",
        };
        static readonly CreateMovieDTO data11 = new CreateMovieDTO()
        {
            Actors = "Test",
            Genre = "Ganre1",
            Keywords = new List<string>
                {
                  "Test1","Test2","Test3","rado",
                },
            Plot = "Plto01",
            Producer = "T.Test",
            Title = "TTest01",
        };

        [Test]
        public void CreateMovieCheck()
        {
            int id = this.movieService.CreateMovie(data10);

            Assert.AreEqual(data10.Title, this.movieService.GetMovie(id).Title);

            var abmovie = this.dbContext.Movies.First(x => x.Title == "TTest");
            this.dbContext.Movies.Remove(abmovie);
            this.dbContext.SaveChanges();
        }
        [Test]
        public void SearchMovieShouldBeTRUE()
        {
            var movie = this.movieService.CreateMovie(data10);
            var movie1 = this.movieService.CreateMovie(data11);

            List<Movie> movies213 = this.movieService.SearchMovies("TTitle");

            Assert.AreEqual(movies213.Count , 2);
            var abmovie = this.dbContext.Movies.First(x => x.Title == "TTest");
            var acmovie = this.dbContext.Movies.First(x => x.Title == "TTest01");
            this.dbContext.Movies.Remove(abmovie);
            this.dbContext.Movies.Remove(acmovie);
            this.dbContext.SaveChanges();

        }

        [Test]
        public void DelMovies()
        {
            int id = this.movieService.CreateMovie(data10);

            bool reslut = this.movieService.DeleteMovie(id);

            Assert.IsTrue(reslut);
        }


        //Still not Working
        //[Test]
        //public void GetNumberOfMoviesShouldBeN()
        //{
        //    var movie = this.movieService.CreateMovie(data10);

        //    List<Movie> movies = this.movieService.GetNumberOfMovies(0, int.MaxValue);

        //    Assert.AreEqual(movies.Count, 1);

        //    var abmovie = this.dbContext.Movies.First(x => x.Title == "TTest");
        //    this.dbContext.Movies.Remove(abmovie);

        //}

    }
}
