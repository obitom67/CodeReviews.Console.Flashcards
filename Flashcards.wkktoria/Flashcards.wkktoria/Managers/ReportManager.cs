using Flashcards.wkktoria.Controllers;
using Flashcards.wkktoria.Services;
using Flashcards.wkktoria.UserInteractions;
using Flashcards.wkktoria.UserInteractions.Helpers;

namespace Flashcards.wkktoria.Managers;

internal class ReportManager
{
    private readonly ReportDataController _reportDataController;

    internal ReportManager(StackService stackService, SessionService sessionService,
        ReportDataService reportDataService)
    {
        _reportDataController = new ReportDataController(stackService, sessionService, reportDataService);
    }

    private static void ShowMenu()
    {
        UserOutput.InfoMessage("""
                               0 - Return
                               1 - Report number of sessions per month
                               2 - Report average score per month
                               """);
    }

    internal void Run()
    {
        var quit = false;

        while (!quit)
        {
            Console.Clear();
            ShowMenu();

            Console.Write("> ");
            var option = Console.ReadLine();

            switch (option!.Trim())
            {
                case "0":
                    quit = true;
                    break;
                case "1":
                    _reportDataController.ReportSessions();
                    break;
                case "2":
                    _reportDataController.ReportAverageScores();
                    break;
                default:
                    UserOutput.ErrorMessage("Invalid option.");
                    ConsoleHelpers.PressToContinue();
                    break;
            }
        }
    }
}