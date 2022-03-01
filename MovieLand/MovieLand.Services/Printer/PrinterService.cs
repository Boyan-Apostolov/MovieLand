using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Common;
using MovieLand.Services.Movies;
using MovieLand.Services.Users;

namespace MovieLand.Services.Printer
{
    public class PrinterService : IPrinterService
    {
        private readonly IMovieService movieService;
        private readonly IUserService userService;

        public PrinterService(IMovieService movieService,
                              IUserService userService)
        {
            this.movieService = movieService;
            this.userService = userService;
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
            var result = "Available commands: help; info [id]; ";

            if (this.userService.IsUserAuthenticated())
            {
                result += "review [id]; watched [id]; ";

                if(this.userService.IsUserAdmin()) result += "create ; delete [id]; ";
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
            
            var sb = new StringBuilder();
            sb.AppendLine("Commands Info:")
                .AppendLine("login -> allows the user to login to the platform")
                .AppendLine("register -> creates a profile for the user by given email, username and password")
                .AppendLine("help -> shows all the commands with their explanations")
                .AppendLine("watched [id] -> by giving the id of the movie, the LOGGED user adds it to their collection of watched movies")
                .AppendLine("review [id] -> after giving the id of a movie, the user can submit a review for the movie they have watched")
                .AppendLine("info [id] -> the user is shown all the information about a movie - title, plot, etc")
                .AppendLine("create/delete [id] -> only the admin has access to these commands which can help him moderate the platform");

            Console.WriteLine(sb.ToString().Trim());
            this.ClearConsoleColor();
        }

        public void StartingCreatingMovie()
        {
            if (this.userService.IsUserAdmin())
            {
                Console.Clear();
                Console.WriteLine("Movie id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Movie title:");
                string title = Console.ReadLine();
                Console.WriteLine("Movie plot:");
                string plot = Console.ReadLine();
                Console.WriteLine("Movie producer:");
                string producer = Console.ReadLine();
                Console.WriteLine("Movie genre:");
                string genre = Console.ReadLine();
                Console.WriteLine("Movie actors:");
                string actors = Console.ReadLine();
                Console.WriteLine("Movie key words:");
                ICollection<string> keyWords = Console.ReadLine().Split();

                this.movieService.CreateMovie(id, title, plot, producer, genre, actors, keyWords);
                Console.WriteLine("Movie was created successfully.");
                Console.Clear();
            }
        }

        public void DeleteMovie(List<string> tokens)
        {
            int id = int.Parse(tokens[1]);
            if (this.userService.IsUserAdmin())
            {
                var movie = movieService.GetMovie(id);
                AssuranceForDeletingMovie();
                string answer = Console.ReadLine();
                bool isConferned = true;
                if (answer == "Yes")
                {
                    isConferned = true;
                }
                else
                {
                    isConferned = false;
                }
                if (isConferned == true)
                {
                    this.movieService.DeleteMovie(id);
                }

            }
        }

        public void AssuranceForDeletingMovie()
        {
            Console.WriteLine("Are you sure you want to delete this movie?");
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
    }
}
