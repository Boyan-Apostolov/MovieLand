using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLand.Common;
using MovieLand.Services.Movies;
using MovieLand.Services.Reviews;
using MovieLand.Services.Users;

namespace MovieLand.Services.Printer
{
    public class PrinterService : IPrinterService
    {
        private readonly IMovieService movieService;
        private readonly IUserService userService;
        private readonly IReviewsService reviewsService;

        public PrinterService(IMovieService movieService,
                              IUserService userService,
                              IReviewsService reviewsService)
        {
            this.movieService = movieService;
            this.userService = userService;
            this.reviewsService = reviewsService;
        }

        public void ShowWelcomeMessage()
        {
            Console.WriteLine(this.PrintSeparatorLine());

            var message = GlobalConstants.PrinterConfigs.WelcomeMessage;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);

            Console.WriteLine(this.PrintSeparatorLine());
        }

        public void ShowAvailableCommands()
        {
            this.SetColorToGreen();
            var result = "Available commands: help; info [id]; page [number]; ";

            if (this.userService.IsUserAuthenticated())
            {
                result += "review [id]; watched [id]; ";

                if (this.userService.IsUserAdmin()) result += "create ; delete [id]; ";
            }
            else
            {
                result += "login; register;";
            }

            Console.WriteLine(result);
            this.ClearConsoleColor();
        }

        public void PrintNumberOfMovies(int countToSkip, int countToGet)
        {
            var movies = this.movieService.GetNumberOfMovies(countToSkip, countToGet);

            this.SetColorToYellow();
            Console.WriteLine(this.PrintHomeRow(new[] { "Id", "Title", "Actors", "Producer" }));
            this.ClearConsoleColor();

            foreach (var movie in movies)
            {
                Console.WriteLine(
                    this.PrintHomeRow(new[] { movie.Id.ToString(), movie.Title, string.Join(", ", movie.Actors), movie.Producer })
                    );
            }
        }

        public void ShowCommandsInfo()
        {
            this.SetColorToYellow();
            Console.WriteLine(string.Join(Environment.NewLine, GlobalConstants.AvailableCommands));
            this.ClearConsoleColor();
        }

        public void StartingCreatingMovie()
        {
            if (this.userService.IsUserAuthenticated() && this.userService.IsUserAdmin())
            {
                Console.Clear();
                Console.Write("Movie title: ");
                string title = Console.ReadLine();
                Console.Write("Movie plot: ");
                string plot = Console.ReadLine();
                Console.Write("Movie producer: ");
                string producer = Console.ReadLine();
                Console.Write("Movie genre: ");
                string genre = Console.ReadLine();
                Console.Write("Movie actors: ");
                string actors = Console.ReadLine();
                Console.Write("Movie key words: ");
                ICollection<string> keyWords = Console.ReadLine().Split();

                this.movieService.CreateMovie(title, plot, producer, genre, actors, keyWords);
                Console.Clear();
                Console.WriteLine("Movie was created successfully.");
            }
            else
            {
                throw new Exception("Access denied!");
            }
        }

        public void DeleteMovie(List<string> tokens)
        {
            this.SetColorToRed();

            int id = int.Parse(tokens[1]);
            if (this.userService.IsUserAuthenticated() && this.userService.IsUserAdmin())
            {
                if (AssuranceForDeletingMovie())
                {
                    var isDeleted = this.movieService.DeleteMovie(id);

                    Console.WriteLine(isDeleted ? "Movie deleted successfully!" : "Movie not deleted!");
                    this.ClearConsoleColor();
                }
            }
            else
            {
                throw new Exception("Access denied!");
            }
        }

        public string AskEmail()
        {
            Console.WriteLine("ENTER Email:");
            string result = Console.ReadLine();
            return result;
        }
        public string AskUsername()
        {
            Console.WriteLine("ENTER Username:");
            string result = Console.ReadLine();
            return result;
        }
        public string AskPassword()
        {
            Console.WriteLine("ENTER Password:");
            string result = Console.ReadLine();
            return result;
        }

        public void PrintError(string errorMessage)
        {
            this.SetColorToRed();
            Console.WriteLine(errorMessage);
            this.ClearConsoleColor();
        }

        public void InfoAboutMovie(List<string> tokens)
        {
            Console.Clear();

            var sb = new StringBuilder();

            var movieId = int.Parse(tokens[1]);
            var movieInfo = this.movieService.GetMovie(movieId);

            if (movieInfo == null) throw new Exception("Movie not found!");

            var reviews = this.reviewsService.GetMovieReviews(movieId);

            this.SetColorToYellow();
            Console.WriteLine($"Title: {movieInfo.Title}");
            this.ClearConsoleColor();

            sb
                .AppendLine($"Genre: {movieInfo.Genre}")
                .AppendLine($"Plot: {movieInfo.Plot.Substring(0, Math.Min(movieInfo.Plot.Length, 200))}...")
                .AppendLine($"Actors: {movieInfo.Actors}")
                .AppendLine();

            if (reviews.Any())
            {
                sb.AppendLine($"Reviews: {reviews.Average(x => x.Grade)}");
                foreach (var review in reviews)
                {
                    sb.AppendLine($"{review.Grade}/10 -> {review.ReviewText}")
                        .AppendLine($"By: {review.User.UserName}, on: {review.CreatedOn.ToShortDateString()}")
                        .AppendLine(this.PrintSeparatorLine());
                }
            }
            else
            {
                sb.AppendLine("No reviews!");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public void ShowMovieCommands()
        {
            this.SetColorToGreen();
            Console.WriteLine("Available commands: back; review; watched; ");
            this.ClearConsoleColor();
        }

        private bool AssuranceForDeletingMovie()
        {
            Console.Write("Are you sure you want to delete this movie? [Y/n] ");

            return Console.ReadLine() == "Y";
        }

        public string PrintHomeRow(string[] columns)
        {
            var sb = new StringBuilder();

            sb.Append(PrintLinePart(columns[0], GlobalConstants.PrinterConfigs.IdColumnWidth))
                .Append(PrintLinePart(columns[1], GlobalConstants.PrinterConfigs.TitleColumnWidth))
                .Append(PrintLinePart(columns[2], GlobalConstants.PrinterConfigs.ActorsColumnWidth))
                .Append(PrintLinePart(columns[3], GlobalConstants.PrinterConfigs.DirectorColumnWidth, isLast: true))
                .Append(this.PrintSeparatorLine());

            return sb.ToString().Trim();
        }

        private string PrintLinePart(string text, int columnWidth, bool isLast = false)
        {
            string row = isLast ?
                GlobalConstants.PrinterConfigs.ColumnSeparator + GetCenterAlignedText(text, columnWidth) + GlobalConstants.PrinterConfigs.ColumnSeparator :
                GlobalConstants.PrinterConfigs.ColumnSeparator + GetCenterAlignedText(text, columnWidth);

            if (!isLast)
                return row;
            else
                return row + Environment.NewLine;
        }

        private string GetCenterAlignedText(string text, int columnWidth)
        {
            text = text.Length > columnWidth ? text.Substring(0, columnWidth - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', columnWidth)
                : text.PadRight(columnWidth - ((columnWidth - text.Length) / 2)).PadLeft(columnWidth);
        }


        private string PrintSeparatorLine()
        {
            return new string('-', GlobalConstants.PrinterConfigs.TableWidth);
        }

        private void ClearConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetColorToGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private void SetColorToYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private void SetColorToRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
