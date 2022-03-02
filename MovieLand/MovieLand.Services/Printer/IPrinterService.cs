using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.Printer
{
    public interface IPrinterService
    {
        public void ShowWelcomeMessage();

        public void ShowAvailableCommands();

        public void PrintNumberOfMovies(int countToSkip, int countToGet);

        public void ShowCommandsInfo();

        public void StartingCreatingMovie();

        public void DeleteMovie(List<string> tokens);

        void PrintError(string errorMessage);
    }
}
