using System;
using MovieLand.Data;
using MovieLand.Services.Emailing;
using MovieLand.Services.Movies;
using MovieLand.Services.Printer;
using MovieLand.Services.Reviews;
using MovieLand.Services.Seeder;
using MovieLand.Services.Users;

namespace MovieLand.Tests
{
    public class BaseTestClass
    {
        public IEmailSenderService emailService;
        public IMovieService movieService;
        public IPrinterService printerService;
        public IReviewsService reviewsService;
        public ISeederService seederService;
        public IUserService userService;

        public MovieLandDbContext dbContext;

        public BaseTestClass()
        {
            this.emailService = new EmailSenderService();
            this.movieService = new MovieService(dbContext);
            this.reviewsService = new ReviewsService(dbContext);
            this.seederService = new SeederService(dbContext);
            this.userService = new UserService(dbContext);

            this.printerService =
                new PrinterService(movieService, userService, reviewsService, seederService, emailService);
        }
    }
}