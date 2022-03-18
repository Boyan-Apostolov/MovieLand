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
            Title = "TTestTEST_CASE",
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
            Title = "TTest01TEST_CASE",
        };

        [Test]
        public void CreateMovieCheck()
        {
            int id = this.movieService.CreateMovie(data10);

            Assert.AreEqual(data10.Title, this.movieService.GetMovie(id).Title);

            this.RemoveMovie("TTestTEST_CASE");
        }

        [Test]
        public void SearchMovieShouldBeTRUE()
        {
            var movie = this.movieService.CreateMovie(data10);
            var movie1 = this.movieService.CreateMovie(data11);

            List<Movie> movies213 = this.movieService.SearchMovies("TEST_CASE");

            Assert.AreEqual(movies213.Count , 2);

            this.RemoveMovie("TTestTEST_CASE");
            this.RemoveMovie("TTest01TEST_CASE");

        }

        [Test]
        public void DelMoviesShouldRemoveThem()
        {
            int id = this.movieService.CreateMovie(data10);

            bool reslut = this.movieService.DeleteMovie(id);

            Assert.IsTrue(reslut);
            Assert.Null(this.dbContext.Movies.FirstOrDefault(x=>x.Id == id));
        }

        [Test]
        public void GetNumberOfMoviesShouldBeN()
        {
            var movie = this.movieService.CreateMovie(data10);

            List<Movie> movies = this.movieService.GetNumberOfMovies(0, int.MaxValue);

            Assert.AreEqual( movies.Count,this.dbContext.Movies.Count());

            this.RemoveMovie("TTestTEST_CASE");
        }

        private void RemoveMovie(string title)
        {
            var movie = this.dbContext.Movies.First(x => x.Title == title);
            this.dbContext.Movies.Remove(movie);
            this.dbContext.SaveChanges();
        }
    }
}
