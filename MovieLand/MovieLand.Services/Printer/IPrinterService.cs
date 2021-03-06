using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Services.Printer
{
    public interface IPrinterService
    {
        public string AskIdentificator();

        public string AskUsername();

        public string AskEmail();
        
        public string AskPassword();

        public void ShowWelcomeMessage();

        public void ShowAvailableCommands();

        public void PrintNumberOfMovies(int countToSkip, int countToGet);

        public void ShowCommandsInfo();

        public void StartingCreatingMovie();

        public void DeleteMovie(List<string> tokens);

        public Task ReviewMovie(List<string> tokens);

        void PrintError(string errorMessage);
        
        void InfoAboutMovie(List<string> tokens);

        void ShowMovieCommands();
        
        void ShowSearchedMovies(List<string> tokens);
        
        void SeedMovies(List<string> tokens);
    }
}
