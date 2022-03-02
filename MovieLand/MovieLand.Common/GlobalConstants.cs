using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MovieLand.Common
{
    public class GlobalConstants
    {
        public const string Top250MoviesEndpoint = "https://imdb-api.com/en/API/Top250Movies/k_is5zq14v";

        public const string MovieInfoEndpoint = "https://imdb-api.com/en/API/Title/k_is5zq14v/{0}/FullCast";

        public const string AdminEmail = "admin@admin.com";

        public static List<string> AvailableCommands = new List<string>
        {
            "Commands Info:",
            "login -> allows the user to login to the platform",
            "register -> creates a profile for the user by given email, username and password",
            "help -> shows all the commands with their explanations",
            "watched [id] -> by giving the id of the movie, the LOGGED user adds it to their collection of watched movies",
            "review [id] -> after giving the id of a movie, the user can submit a review for the movie they have watched",
            "info [id] -> the user is shown all the information about a movie - title, plot, etc",
            "page [number] -> shows the page with that number",
            "create/delete [id] -> only the admin has access to these commands which can help him moderate the platform"
        };

        public class PrinterConfigs
        {
            public const string ColumnSeparator = "|";

            public const int TableWidth = 119;

            public const int IdColumnWidth = 4;

            public const int TitleColumnWidth = 45;

            public const int ActorsColumnWidth = 50;

            public const int DirectorColumnWidth = 16;

            public const string WelcomeMessage = "Welcome to MovieLand";
            
            public const int DefaultNumberOfShownMovies = 10;
        }
    }
}
