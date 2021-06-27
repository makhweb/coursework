using System;
using Program.Commands;

namespace Program
{
    static class CommandsHandler
    {
        private static bool HasError = false;
        private enum Commands : int
        {
            List = 1,
            Search,
            Create,
            Exit = 0
        }

        public static void Handle()
        {
            ShowMenu();

            Console.Write("Buyruq: ");
            bool success = Enum.TryParse<Commands>(
                Console.ReadLine(),
                out Commands command
            );

            if (success == false)
            {
                HasError = true;
                Handle();
                return;
            }

            bool commandFound = true;

            switch (command)
            {
                case Commands.List:
                    ListCommand.Handle();
                    break;
                case Commands.Create:
                    CreateCommand.Handle();
                    break;
                case Commands.Search:
                    SearchCommand.Handle();
                    break;
                case Commands.Exit:
                    return;
                default:
                    commandFound = false;
                    break;
            }

            HasError = !commandFound;
            Handle();
        }

        private static void ShowMenu()
        {
            if (HasError)
                StyledConsole.ShowError("Noto'gri buyruq kiritildi!");
            else
                StyledConsole.ShowHeaderMessage("Menyu (Buyruq indeksini yozing.)");

            Console.WriteLine("[1] - Qoidalar ro'yhati");
            Console.WriteLine("[2] - Qidiruv");
            Console.WriteLine("[3] - Yangi qoida kiritish");
            Console.WriteLine("[0] - Dasturdan chiqish");
            Console.WriteLine();
        }
    }
}
