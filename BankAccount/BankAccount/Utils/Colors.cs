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

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
    }
}