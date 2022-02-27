using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MovieLand.Data;
using MovieLand.Services.Controller;
using MovieLand.Services.Movies;
using MovieLand.Services.Printer;
using MovieLand.Services.Seeder;
using MovieLand.Services.Users;

namespace MovieLand.Services.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieLandDbContext>();

            builder.RegisterType<ControllerService>();

            builder.RegisterType<MovieService>().As<IMovieService>();
            builder.RegisterType<PrinterService>().As<IPrinterService>();
            builder.RegisterType<SeederService>().As<ISeederService>();
            builder.RegisterType<UserService>().As<IUserService>();

            return builder.Build();
        }
    }
}
