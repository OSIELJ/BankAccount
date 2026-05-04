using BankAccount.Controllers;
using BankAccount.Models;
using BankAccount.Utils;

var controller = new AccountController();
var running = true;

while (running)
{
    Console.Clear();
    Colors.Cyan("╔════════════════════════════════╗");
    Colors.Cyan($"║{Language.MenuTitle}║");
    Colors.Cyan("╚════════════════════════════════╝");
    Colors.Yellow(Language.OptCreateChecking);
    Colors.Yellow(Language.OptCreateSavings);
    Colors.Yellow(Language.OptListAll);
    Colors.Yellow(Language.OptFind);
    Colors.Yellow(Language.OptDeposit);
    Colors.Yellow(Language.OptWithdraw);
    Colors.Yellow(Language.OptTransfer);
    Colors.Yellow(Language.OptDelete);
    Colors.Yellow(Language.OptUpdate);
    Colors.Yellow(Language.OptLanguage);
    Colors.Red("\n" + Language.OptExit);
    Colors.White(Language.ChooseOption);

    string option = Console.ReadLine() ?? "";

    switch (option.ToUpper())
    {
        case "1":
            Console.Clear();
            Colors.Cyan(Language.CreateChecking);
            Console.Write(Language.OwnerName);
            string ccOwner = Console.ReadLine() ?? "";
            Console.Write(Language.InitialBalance);
            decimal ccBalance = decimal.TryParse(Console.ReadLine(), out var cb) ? cb : 0;
            Console.Write(Language.LimitDefault);
            decimal ccLimit = decimal.TryParse(Console.ReadLine(), out var cl) ? cl : 1000;
            controller.Create(new CheckingAccount(ccOwner, ccBalance, ccLimit));
            break;

        case "2":
            Console.Clear();
            Colors.Cyan(Language.CreateSavings);
            Console.Write(Language.OwnerName);
            string saOwner = Console.ReadLine() ?? "";
            Console.Write(Language.InitialBalance);
            decimal saBalance = decimal.TryParse(Console.ReadLine(), out var sb) ? sb : 0;
            controller.Create(new SavingsAccount(saOwner, saBalance));
            break;

        case "3":
            Console.Clear();
            Colors.Cyan(Language.ListAll);
            controller.ListAll();
            break;

        case "4":
            Console.Clear();
            Colors.Cyan(Language.FindAccount);
            Console.Write(Language.AccountNumber);
            int findNum = int.TryParse(Console.ReadLine(), out var fn) ? fn : 0;
            var found = controller.FindByNumber(findNum);
            if (found != null) Colors.Green(found.ToString()!);
            else Colors.Red(Language.AccountNotFound);
            break;

        case "5":
            Console.Clear();
            Colors.Cyan(Language.Deposit);
            Console.Write(Language.AccountNumber);
            int depNum = int.TryParse(Console.ReadLine(), out var dn) ? dn : 0;
            var depAcc = controller.FindByNumber(depNum);
            if (depAcc == null) { Colors.Red(Language.AccountNotFound); break; }
            Colors.Yellow(depAcc.ToString()!);
            Console.Write(Language.Amount);
            decimal depAmt = decimal.TryParse(Console.ReadLine(), out var da) ? da : 0;
            if (controller.Deposit(depNum, depAmt))
                Colors.Green(controller.FindByNumber(depNum)!.ToString()!);
            break;

        case "6":
            Console.Clear();
            Colors.Cyan(Language.Withdraw);
            Console.Write(Language.AccountNumber);
            int witNum = int.TryParse(Console.ReadLine(), out var wn) ? wn : 0;
            var witAcc = controller.FindByNumber(witNum);
            if (witAcc == null) { Colors.Red(Language.AccountNotFound); break; }
            Colors.Yellow(witAcc.ToString()!);
            Console.Write(Language.Amount);
            decimal witAmt = decimal.TryParse(Console.ReadLine(), out var wa) ? wa : 0;
            if (controller.Withdraw(witNum, witAmt))
                Colors.Green(controller.FindByNumber(witNum)!.ToString()!);
            break;

        case "7":
            Console.Clear();
            Colors.Cyan(Language.Transfer);
            Console.Write(Language.OriginAccount);
            int oriNum = int.TryParse(Console.ReadLine(), out var on) ? on : 0;
            var oriAcc = controller.FindByNumber(oriNum);
            if (oriAcc == null) { Colors.Red(Language.AccountNotFound); break; }
            Colors.Yellow(oriAcc.ToString()!);
            Console.Write(Language.DestinyAccount);
            int desNum = int.TryParse(Console.ReadLine(), out var den) ? den : 0;
            var desAcc = controller.FindByNumber(desNum);
            if (desAcc == null) { Colors.Red(Language.AccountNotFound); break; }
            Colors.Yellow(desAcc.ToString()!);
            Console.Write(Language.Amount);
            decimal traAmt = decimal.TryParse(Console.ReadLine(), out var ta) ? ta : 0;
            if (controller.Transfer(oriNum, desNum, traAmt))
            {
                Colors.Yellow(controller.FindByNumber(oriNum)!.ToString()!);
                Colors.Green(controller.FindByNumber(desNum)!.ToString()!);
            }
            break;

        case "8":
            Console.Clear();
            Colors.Cyan(Language.DeleteAccount);
            Console.Write(Language.AccountNumber);
            int delNum = int.TryParse(Console.ReadLine(), out var deln) ? deln : 0;
            var accToDelete = controller.FindByNumber(delNum);
            if (accToDelete == null)
            {
                Colors.Red(Language.AccountNotFound);
                break;
            }
            Colors.Yellow(accToDelete.ToString()!);
            Console.Write(Language.ConfirmDelete);
            string confirm = Console.ReadLine() ?? "";
            if (confirm.ToUpper() == "S" || confirm.ToUpper() == "Y")
                controller.Delete(delNum);
            else
                Colors.Red(Language.DeleteCancelled);
            break;

        case "9":
            Console.Clear();
            Colors.Cyan(Language.UpdateAccount);
            Console.Write(Language.AccountNumber);
            int updNum = int.TryParse(Console.ReadLine(), out var un) ? un : 0;
            var updAccount = controller.FindByNumber(updNum);
            if (updAccount == null)
            {
                Colors.Red(Language.AccountNotFound);
                break;
            }
            Colors.Green(updAccount.ToString()!);
            Console.Write(Language.NewOwnerName);
            string newOwner = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(newOwner))
                updAccount.Owner = newOwner;
            controller.Update(updAccount);
            Colors.Green(updAccount.ToString()!);
            break;

        case "L":
            Console.Clear();
            Colors.Cyan(Language.SelectLanguage);
            Colors.Yellow(Language.LangPTBR);
            Colors.Yellow(Language.LangEN);
            Colors.White(Language.ChooseOption);
            string langOpt = Console.ReadLine() ?? "";
            if (langOpt == "1") Language.Set(AppLanguage.PTBR);
            else if (langOpt == "2") Language.Set(AppLanguage.EN);
            Colors.Green(Language.LangChanged);
            break;

        case "0":
            running = false;
            Colors.Green(Language.Goodbye);
            break;

        default:
            Colors.Red(Language.InvalidOption);
            break;
    }

    if (running)
    {
        Colors.White(Language.PressAnyKey);
        Console.ReadKey();
    }
}