using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Utils
{
    public static class Colors
    {
        public static void Green(string text) =>
            Print(text, ConsoleColor.Green);

        public static void Red(string text) =>
            Print(text, ConsoleColor.Red);

        public static void Yellow(string text) =>
            Print(text, ConsoleColor.Yellow);

        public static void Cyan(string text) =>
            Print(text, ConsoleColor.Cyan);

        public static void White(string text) =>
            Print(text, ConsoleColor.White);

        private static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
