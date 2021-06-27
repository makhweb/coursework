using System;

namespace Program
{
    static class StyledConsole
    {
        public static void ShowError(string message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            ShowStyledMessage(message);

            ResetConsoleStyles();
        }

        public static void ShowHeaderMessage(string message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            StyledConsole.ShowStyledMessage(message);

            StyledConsole.ResetConsoleStyles();
        }

        public static void ShowSuccessMessage(string message)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            StyledConsole.ShowStyledMessage(message);

            StyledConsole.ResetConsoleStyles();
        }

        public static void ShowStyledMessage(string message, int margin = 3, int startNewLine = 1, int endNewLine = 1)
        {
            int spaces = 2 * margin + message.Length;

            Console.Write(new String('\n', startNewLine));
            Console.WriteLine(new String(' ', spaces));
            Console.WriteLine(new String(' ', margin) + message + new String(' ', margin));
            Console.WriteLine(new String(' ', spaces));
            Console.Write(new String('\n', endNewLine));
        }

        public static void ResetConsoleStyles()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
