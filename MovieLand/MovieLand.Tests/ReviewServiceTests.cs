using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MovieLand.Data.Models;
using MovieLand.Services.Reviews;

namespace MovieLand.Tests
{
    public class ReviewServiceTests : BaseTestClass
    {
        static readonly Review pesho = new Review()
        {
            Grade = 4,
            MovieId = 12,
            ReviewText = "aedarytrte wertsdfg",
            UserId = 3,
            CreatedOn = DateTime.Now,
        };
        [Test]
        public void CreateReviewCheck()
        {

        }
    }
}
