using BankAccount.Controllers;
using BankAccount.Models;
using BankAccount.Utils;

var controller = new AccountController();
var running = true;

while (running)
{
    Console.Clear();
    Colors.Cyan("╔════════════════════════════════╗");
    Colors.Cyan("║       BANK ACCOUNT SYSTEM      ║");
    Colors.Cyan("╚════════════════════════════════╝");
    Colors.Yellow("\n  1 - Create Checking Account");
    Colors.Yellow("  2 - Create Savings Account");
    Colors.Yellow("  3 - List All Accounts");
    Colors.Yellow("  4 - Find Account");
    Colors.Yellow("  5 - Deposit");
    Colors.Yellow("  6 - Withdraw");
    Colors.Yellow("  7 - Transfer");
    Colors.Yellow("  8 - Delete Account");
    Colors.Red("\n  0 - Exit");
    Colors.White("\n  Choose an option: ");

    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            Console.Clear();
            Colors.Cyan("=== Create Checking Account ===");
            Console.Write("Owner name: ");
            string ccOwner = Console.ReadLine() ?? "";
            Console.Write("Initial balance: ");
            decimal ccBalance = decimal.TryParse(Console.ReadLine(), out var cb) ? cb : 0;
            Console.Write("Limit (default 1000): ");
            decimal ccLimit = decimal.TryParse(Console.ReadLine(), out var cl) ? cl : 1000;
            controller.Create(new CheckingAccount(ccOwner, ccBalance, ccLimit));
            break;

        case "2":
            Console.Clear();
            Colors.Cyan("=== Create Savings Account ===");
            Console.Write("Owner name: ");
            string saOwner = Console.ReadLine() ?? "";
            Console.Write("Initial balance: ");
            decimal saBalance = decimal.TryParse(Console.ReadLine(), out var sb) ? sb : 0;
            controller.Create(new SavingsAccount(saOwner, saBalance));
            break;

        case "3":
            Console.Clear();
            controller.ListAll();
            break;

        case "4":
            Console.Clear();
            Colors.Cyan("=== Find Account ===");
            Console.Write("Account number: ");
            int findNum = int.TryParse(Console.ReadLine(), out var fn) ? fn : 0;
            var found = controller.FindByNumber(findNum);
            if (found != null) Colors.Green(found.ToString()!);
            else Colors.Red("Account not found.");
            break;

        case "5":
            Console.Clear();
            Colors.Cyan("=== Deposit ===");
            Console.Write("Account number: ");
            int depNum = int.TryParse(Console.ReadLine(), out var dn) ? dn : 0;
            Console.Write("Amount: ");
            decimal depAmt = decimal.TryParse(Console.ReadLine(), out var da) ? da : 0;
            controller.Deposit(depNum, depAmt);
            break;

        case "6":
            Console.Clear();
            Colors.Cyan("=== Withdraw ===");
            Console.Write("Account number: ");
            int witNum = int.TryParse(Console.ReadLine(), out var wn) ? wn : 0;
            Console.Write("Amount: ");
            decimal witAmt = decimal.TryParse(Console.ReadLine(), out var wa) ? wa : 0;
            controller.Withdraw(witNum, witAmt);
            break;

        case "7":
            Console.Clear();
            Colors.Cyan("=== Transfer ===");
            Console.Write("Origin account number: ");
            int oriNum = int.TryParse(Console.ReadLine(), out var on) ? on : 0;
            Console.Write("Destiny account number: ");
            int desNum = int.TryParse(Console.ReadLine(), out var den) ? den : 0;
            Console.Write("Amount: ");
            decimal traAmt = decimal.TryParse(Console.ReadLine(), out var ta) ? ta : 0;
            controller.Transfer(oriNum, desNum, traAmt);
            break;

        case "8":
            Console.Clear();
            Colors.Cyan("=== Delete Account ===");
            Console.Write("Account number: ");
            int delNum = int.TryParse(Console.ReadLine(), out var deln) ? deln : 0;
            controller.Delete(delNum);
            break;

        case "0":
            running = false;
            Colors.Green("\nGoodbye!");
            break;

        default:
            Colors.Red("Invalid option.");
            break;
    }

    if (running)
    {
        Colors.White("\nPress any key to continue...");
        Console.ReadKey();
    }
}