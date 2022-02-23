using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.PrinterService
{
    public interface IPrinterService
    {
        public void ShowWelcomeMessage();

        public void ShowAvailableCommands();

        public void PrintNumberOfMovies(int countToSkip, int countToGet);

        public void ShowCommandsInfo();
    }
}
