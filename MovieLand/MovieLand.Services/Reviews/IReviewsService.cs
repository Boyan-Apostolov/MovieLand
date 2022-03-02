﻿using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;

namespace MovieLand.Services.Reviews
{
    public interface IReviewsService
    {
        List<Review> GetMovieReviews(int movieId);
    }
}
