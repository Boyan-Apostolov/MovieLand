using System;
using System.Collections.Generic;
using System.Linq;
using MovieLand.Common;
using MovieLand.Data;
using MovieLand.Services.Movies;
using MovieLand.Services.Printer;
using MovieLand.Services.Seeder;
using MovieLand.Services.Users;

namespace MovieLand.Services.Controller
{
    public class ControllerService : IControllerService
    {
        private readonly MovieLandDbContext dbContext;

        private IUserService userService;
        private IMovieService movieService;
        private IPrinterService printerService;
        private ISeederService seederService;

        public ControllerService(MovieLandDbContext dbContext,
                                ISeederService seederService,
                                IMovieService movieService,
                                IUserService userService,
                                IPrinterService printerService)
        {
            this.dbContext = dbContext;
            this.seederService = seederService;
            this.movieService = movieService;
            this.userService = userService;
            this.printerService = printerService;
        }

        public void ShowHomePage()
        {
            this.printerService.ShowWelcomeMessage();
            this.printerService.PrintNumberOfMovies(0, GlobalConstants.PrinterConfigs.DefaultNumberOfShownMovies);
            this.printerService.ShowAvailableCommands();
        }

        public void Run()
        {
            ShowHomePage();
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
                    default:
                        //TODO: add error
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
            this.printerService.StartingCreatingMovie();
            ShowHomePage();
        }

        private void DeleteCommand(List<string> tokens)
        {
            //TODO:
            //Check if user has permissions(is admin)!!!
            //Ask for confirmation
            //Delete movie by id and go to home
            this.printerService.StartingCreatingMovie();
            ShowHomePage();

        }

        private void InfoCommand(List<string> tokens)
        {
            //TODO:
            //Show the user info about the movie - title, reviews(if any), director, plot etc
        }
    }
}
