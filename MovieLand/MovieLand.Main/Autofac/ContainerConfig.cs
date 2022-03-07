using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MovieLand.Data;
using MovieLand.Main;
using MovieLand.Services.Emailing;
using MovieLand.Services.Movies;
using MovieLand.Services.Printer;
using MovieLand.Services.Reviews;
using MovieLand.Services.Seeder;
using MovieLand.Services.Users;

namespace MovieLand.Main.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieLandDbContext>();

            builder.RegisterType<Controller>();

            builder.RegisterType<MovieService>().As<IMovieService>();
            builder.RegisterType<PrinterService>().As<IPrinterService>();
            builder.RegisterType<SeederService>().As<ISeederService>();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<ReviewsService>().As<IReviewsService>();
            builder.RegisterType<EmailSenderService>().As<IEmailSenderService>();

            return builder.Build();
        }
    }
}
