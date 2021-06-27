using System;

using System.IO;

using System.Linq;

namespace Program.Commands
{
    static class SearchCommand
    {
        public static void Handle(bool hasError = false)
        {
            if (hasError)
                StyledConsole.ShowError("Birorta qoida topilmadi.");
            else
                StyledConsole.ShowHeaderMessage("Qoida qidirish");

            Console.WriteLine("[00] - Asosiy menyuga qaytish\n");
            Console.Write("Qoida nomini yozing: ");
            string input = Console.ReadLine();

            if (input == "00")
                return;

            var foundModels = Database.SearchByTitle(input);

            if (foundModels.Count() == 0)
            {
                Handle(true);
                return;
            }

            ListCommand.Handle(foundModels.ToList());
        }
    }
}
