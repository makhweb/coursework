using System;

using System.Collections.Generic;

namespace Program.Commands
{
    static class ListCommand
    {
        private static List<Model> Models;

        public static void Handle(List<Model> models = null)
        {
            Models = models ?? Database.All();

            ShowInterface();
        }

        private static void ShowInterface(bool hasError = false)
        {
            if (hasError)
                StyledConsole.ShowError("Kiritilgan ID orqali qoida topilmadi.");
            else
                StyledConsole.ShowHeaderMessage("Yo'l harakati qoidalari ro'yhati:");

            foreach (var modelItem in Models)
                Console.WriteLine($"[{modelItem.Id}] - {modelItem.Title}");

            Console.WriteLine();

            Console.WriteLine("[00] - Asosiy menyuga qaytish\n");
            Console.Write("Qoidani ochish uchun uning ID sini yozing: ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int id);

            if (input == "00")
                return;

            Model model = Database.Find(id);

            if (!success || model == null)
            {
                ShowInterface(true);
                return;
            }

            Console.Clear();

            StyledConsole.ShowHeaderMessage($"Qoida #{model.Id}");

            Console.WriteLine($" ID: {model.Id}");
            Console.WriteLine($" Nomi: {model.Title}");
            Console.WriteLine($" Matn: {model.Content}");

            Console.Write("\n[Asosiy menyuga o'tish]");
            Console.ReadKey();
        }
    }
}
