using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieLand.Data;
using MovieLand.Data.Models;

namespace MovieLand.Services.Reviews
{
    public class ReviewsService : IReviewsService
    {
        private readonly MovieLandDbContext dbContext;
        
        public ReviewsService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Review> GetMovieReviews(int movieId)
        {
            return this.dbContext.Reviews
                .Include(x=>x.User)
                .Where(x => x.MovieId == movieId)
                .ToList();
        }

        public void CreateReview(int movieId, double reviewGrade, string reviewText, int userId)
        {
            var review = new Review()
            {
                Grade = reviewGrade,
                MovieId = movieId,
                ReviewText = reviewText,
                UserId = userId,
                CreatedOn = DateTime.Now,
            };

            this.dbContext.Reviews.Add(review);
            this.dbContext.SaveChanges();
        }
    }
}
