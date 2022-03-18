using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MovieLand.Data.Models;
using MovieLand.Services.DTOs;
using MovieLand.Services.Reviews;

namespace MovieLand.Tests
{
    public class ReviewServiceTests : BaseTestClass
    {
        [Test]
        public void CreateReviewCheck()
        {
            var email = Guid.NewGuid().ToString() + "@test.com";
            this.userService.Register(email, email, "Test123");

            var movieId = this.movieService.CreateMovie(new CreateMovieDTO()
            {
                Title = "TestMovie",
                Actors = "Aaa.AA aaaa",
                Genre = "test-genr",
                Keywords = null,
                Plot = "Aaaaa",
                Producer = "aa.a"
            });
            var userId = this.dbContext.Users.First(x => x.Email == email).Id;
            this.reviewsService.CreateReview(movieId, 5, "TEST_CASE", userId);

            Assert.NotNull(this.dbContext.Reviews.First(x => x.ReviewText == "TEST_CASE"));

            this.movieService.DeleteMovie(movieId);
            var user = this.dbContext.Users.First(x => x.Email == email);
            this.dbContext.Users.Remove(user);

            this.dbContext.SaveChanges();
        }

        [Test]
        public void GettingMovieReviewsShouldReturnThem()
        {
            var email = Guid.NewGuid().ToString() + "@test.com";
            this.userService.Register(email, email, "Test123");

            var movieId = this.movieService.CreateMovie(new CreateMovieDTO()
            {
                Title = "TestMovie",
                Actors = "Aaa.AA aaaa",
                Genre = "test-genr",
                Keywords = null,
                Plot = "Aaaaa",
                Producer = "aa.a"
            });
            var userId = this.dbContext.Users.First(x => x.Email == email).Id;
            this.reviewsService.CreateReview(movieId, 5, "TEST_CASE", userId);

            var reviews = this.reviewsService.GetMovieReviews(movieId);
            Assert.AreEqual("TEST_CASE", reviews.First().ReviewText);

            this.movieService.DeleteMovie(movieId);
            var user = this.dbContext.Users.First(x => x.Email == email);
            this.dbContext.Users.Remove(user);

            this.dbContext.SaveChanges();
        }
    }
}
