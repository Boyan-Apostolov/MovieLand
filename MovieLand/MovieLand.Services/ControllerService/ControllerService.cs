using System;
using System.Collections.Generic;
using System.Linq;
using MovieLand.Common;
using MovieLand.Data;
using MovieLand.Services.MovieService;
using MovieLand.Services.PrinterService;
using MovieLand.Services.SeederService;
using MovieLand.Services.UserService;

namespace MovieLand.Services.ControllerService
{
    public class ControllerService : IControllerService
    {
        private readonly MovieLandDbContext dbContext;

        private IUserService userService;
        private IMovieService movieService;
        private IPrinterService printerService;
        private ISeederService seederService;

        public ControllerService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
            LoadServices();
        }

        public void Run()
        {
            this.printerService.ShowWelcomeMessage();
            this.printerService.PrintNumberOfMovies(0, GlobalConstants.PrinterConfigs.DefaultNumberOfShownMovies);
            this.printerService.ShowAvailableCommands();

            string userInput = "";
            while ((userInput = Console.ReadLine()) != "exit")
            {
                var tokens = userInput.Split().ToList();
                switch (tokens[0])
                {
                    case "login":
                        LoginCommand();
                        break;
                    case "register":
                        RegisterCommand();
                        break;
                    case "help":
                        HelpCommand();
                        break;
                    case "review":
                        RegisterCommand();
                        break;
                    case "watched":
                        WatchedCommand(tokens);
                        break;
                    case "create":
                        CreateCommand();
                        break;
                    case "delete":
                        DeleteCommand(tokens);
                        break;
                    case "info":
                        InfoCommand(tokens);
                        break;
                }

                this.printerService.ShowAvailableCommands();
            }

            Console.WriteLine("Goodbye!");
        }

        private void LoginCommand()
        {
            //TODO:
            //Ask user for email, username and password
            //login profile
        }

        private void RegisterCommand()
        {
            //TODO:
            //Ask user for username and password
            //login profile
        }

        private void HelpCommand()
        {
            this.printerService.ShowCommandsInfo();
        }

        private void ReviewCommand(List<string> tokens)
        {
            //TODO:
            //Ask for grade and review text
            //Save review to user and db and go to home
        }

        private void WatchedCommand(List<string> tokens)
        {
            //TODO:
            //Add to user's watched movies collection
        }

        private void CreateCommand()
        {
            //TODO:
            //Check if user has permissions(is admin)!!!
            //Ask for parameters - title, plot, etc
            //Create movie and go to home
        }

        private void DeleteCommand(List<string> tokens)
        {
            //TODO:
            //Check if user has permissions(is admin)!!!
            //Ask for confirmation
            //Delete movie by id and go to home
        }

        private void InfoCommand(List<string> tokens)
        {
            //TODO:
            //Show the user info about the movie - title, reviews(if any), director, plot etc
        }

        private void LoadServices()
        {
            this.userService = new UserService.UserService(this.dbContext);
            this.movieService = new MovieService.MovieService(dbContext);
            this.seederService = new SeederService.SeederService(dbContext);
            this.printerService = new PrinterService.PrinterService(this.movieService, this.userService);
        }
    }
}
