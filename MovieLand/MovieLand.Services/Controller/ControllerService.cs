using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MovieLand.Common;
using MovieLand.Data;
using MovieLand.Services.Movies;
using MovieLand.Services.Printer;
using MovieLand.Services.Seeder;
using MovieLand.Services.Users;
using MovieLand.Services.Reviews;

namespace MovieLand.Services.Controller
{
    public class ControllerService : IControllerService
    {
        private readonly MovieLandDbContext dbContext;

        private IUserService userService;
        private IMovieService movieService;
        private IPrinterService printerService;
        private ISeederService seederService;
        private IReviewsService reviewsService;

        public ControllerService(MovieLandDbContext dbContext,
                                ISeederService seederService,
                                IMovieService movieService,
                                IUserService userService,
                                IPrinterService printerService,
                                IReviewsService reviewsService)
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
        }

        public void Run()
        {
            ShowHomePage();
            this.printerService.ShowAvailableCommands();

            string userInput = "";
            while ((userInput = Console.ReadLine()) != "exit")
            {
                var tokens = userInput.Split().ToList();
                try
                {
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
                        case "search":
                            SearchCommand(tokens);
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
                        case "page":
                            ShowPage(tokens);
                            break;
                        case "seed":
                            SeedCommand(tokens);
                            break;
                        default:
                            throw new Exception("Command not found!");
                    }
                }
                catch (Exception e)
                {
                    this.OnErrorOccurred(e.Message);
                }
                this.printerService.ShowAvailableCommands();
            }

            Console.WriteLine("Goodbye!");
        }

        //Basic paging
        private void ShowPage(List<string> tokens)
        {
            Console.Clear();
            var pageNumber = int.Parse(tokens[1]) - 1;
            this.printerService.ShowWelcomeMessage();
            this.printerService.PrintNumberOfMovies(pageNumber * 10, GlobalConstants.PrinterConfigs.DefaultNumberOfShownMovies);
        }

        private void LoginCommand()
        {
            var loginType = this.printerService.EmailOrUsername();
            if (loginType == "U")
            {
                this.userService.ULogin(this.printerService.AskUsername(), this.printerService.AskPassword());
            }
            else if (loginType == "E")
            {
                this.userService.ELogin(this.printerService.AskEmail(), this.printerService.AskPassword());
            }

            Console.Clear();
            ShowHomePage();
        }

        private void RegisterCommand()
        {
            this.userService.Register(this.printerService.AskEmail(), this.printerService.AskUsername(), this.printerService.AskPassword());

            Console.Clear();
            ShowHomePage();
        }

        private void HelpCommand()
        {
            this.printerService.ShowCommandsInfo();
        }

        private void ReviewCommand(List<string> tokens)
        {
            //TODO:
            //in printer service:
            // -check if user is authenticated
            // -ask for review grade, text
            // -get the userId for the review with this.userService.GetCurrentUser().Id
            // -use reviewsService.CreateReview to add the review
            // -Show home page
            this.printerService.ReviewMovie(tokens);
            Console.Clear();
            ShowHomePage();
        }

        private void SearchCommand(List<string> tokens)
        {
            this.printerService.ShowSearchedMovies(tokens);
        }

        private void CreateCommand()
        {
            this.printerService.StartingCreatingMovie();
            ShowHomePage();
        }

        private void DeleteCommand(List<string> tokens)
        {
            this.printerService.DeleteMovie(tokens);
            ShowHomePage();
        }

        private void InfoCommand(List<string> tokens)
        {
            this.printerService.InfoAboutMovie(tokens);
            this.printerService.ShowMovieCommands();

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "back":
                    Console.Clear();
                    ShowHomePage();
                    break;
                case "review":
                    ReviewCommand(tokens);
                    break;
                case "search":
                    SearchCommand(tokens);
                    break;
                default:
                    throw new Exception("Command not found!");
            }
        }

        private void SeedCommand(List<string> tokens)
        {
            this.printerService.SeedMovies(tokens);
            ShowHomePage();
        }

        private void OnErrorOccurred(string errorMessage)
        {
            this.printerService.PrintError(errorMessage);
        }
    }
}
