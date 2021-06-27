using System;

namespace Program.Commands
{
    static class CreateCommand
    {
        public static void Handle()
        {
            StyledConsole.ShowHeaderMessage("Yangi qoida kiritish");

            (string title, string content) = GetInputData();

            Model model = new Model()
            {
                Id = Database.GetUniqueID(),
                Title = title,
                Content = content
            };

            Database.Create(model);

            StyledConsole.ShowSuccessMessage("Qoida bazaga kiritildi.");

            Console.Write("\n[Asosiy menyuga o'tish]");
            Console.ReadKey();
            return;
        }

        private static (string, string) GetInputData()
        {
            string title, content;
            bool validationFailed = true;

            do
            {
                Console.Write("Nomi: ");
                title = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Matn: ");
                content = Console.ReadLine();
                Console.WriteLine();

                validationFailed = String.IsNullOrEmpty(title.Trim())
                                    || String.IsNullOrEmpty(content.Trim());

                if (validationFailed)
                    StyledConsole.ShowError("Malumot to'liq kiritilmagan.");
            } while (validationFailed);

            return (title, content);
        }
    }
}
