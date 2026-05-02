using BankAccount.Models;
using BankAccount.Repositories;
using BankAccount.Utils;

namespace BankAccount.Controllers
{
    public class AccountController : IAccountRepository
    {
        private List<Account> _accounts;

        public AccountController()
        {
            DatabaseSqlite.Initialize();
            _accounts = DatabaseSqlite.LoadAll();
        }

        public void Create(Account account)
        {
            _accounts.Add(account);
            DatabaseSqlite.Save(account);
            Console.WriteLine($"\nAccount number {account.Number} created successfully!");
        }

        public void ListAll()
        {
            Console.WriteLine("\n=== All Accounts ===");
            if (_accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }
            foreach (var account in _accounts)
                Console.WriteLine(account);
        }

        public Account? FindByNumber(int number)
        {
            return _accounts.FirstOrDefault(a => a.Number == number);
        }

        public void Update(Account account)
        {
            var index = _accounts.FindIndex(a => a.Number == account.Number);
            if (index < 0) { Console.WriteLine("Account not found."); return; }
            _accounts[index] = account;
            DatabaseSqlite.Save(account);
            Console.WriteLine("Account updated successfully!");
        }

        public void Delete(int number)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return; }
            _accounts.Remove(account);
            DatabaseSqlite.Delete(number);
            Console.WriteLine("Account deleted successfully!");
        }

        public bool Withdraw(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return false; }
            bool success = account.Withdraw(amount);
            if (success) DatabaseSqlite.Save(account);
            Console.WriteLine(success ? "Withdraw successful!" : "Insufficient balance.");
            return success;
        }

        public bool Deposit(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return false; }
            bool success = account.Deposit(amount);
            if (success) DatabaseSqlite.Save(account);
            Console.WriteLine(success ? "Deposit successful!" : "Invalid amount.");
            return success;
        }

        public bool Transfer(int originNumber, int destinyNumber, decimal amount)
        {
            var origin = FindByNumber(originNumber);
            var destiny = FindByNumber(destinyNumber);
            if (origin == null || destiny == null)
            { Console.WriteLine("Account not found."); return false; }
            if (!origin.Withdraw(amount))
            { Console.WriteLine("Insufficient balance."); return false; }
            destiny.Deposit(amount);
            DatabaseSqlite.Save(origin);
            DatabaseSqlite.Save(destiny);
            Console.WriteLine("Transfer successful!");
            return true;
        }
    }
}