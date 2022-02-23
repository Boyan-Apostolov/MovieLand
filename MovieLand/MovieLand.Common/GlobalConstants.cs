using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Common
{
    public class GlobalConstants
    {
        public const string Top250MoviesEndpoint = "https://imdb-api.com/en/API/Top250Movies/k_is5zq14v";

        public const string MovieInfoEndpoint = "https://imdb-api.com/en/API/Title/k_is5zq14v/{0}/FullCast";

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
