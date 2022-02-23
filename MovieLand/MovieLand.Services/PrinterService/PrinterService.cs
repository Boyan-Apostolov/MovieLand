using System;
using System.Runtime.CompilerServices;
using System.Text;
using MovieLand.Common;

namespace MovieLand.Services.PrinterService
{
    public class PrinterService : IPrinterService
    {
        private readonly MovieService.MovieService movieService;
        
        public PrinterService(MovieService.MovieService movieService)
        {
            this.movieService = movieService;
        }

        public void ShowWelcomeMessage()
        {
            Console.WriteLine(this.PrintSeparatorLine());

            var message = GlobalConstants.PrinterConfigs.WelcomeMessage;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);

            Console.WriteLine(this.PrintSeparatorLine());
        }

        public string PrintSeparatorLine()
        {
            return new string('-', GlobalConstants.PrinterConfigs.TableWidth);
        }

        public void PrintNumberOfMovies(int countToSkip, int countToGet)
        {
            var movies = this.movieService.GetNumberOfMovies(countToSkip, countToGet);

            Console.WriteLine(this.PrintHomeRow(new[] { "Id", "Title", "Actors", "Producer" }));
            foreach (var movie in movies)
            {
                Console.WriteLine(
                    this.PrintHomeRow(new[] { movie.Id.ToString(), movie.Title, string.Join(", ", movie.Actors), movie.Producer })
                    );
            }
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
    }
}
