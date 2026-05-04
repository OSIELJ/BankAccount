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
            Console.WriteLine($"\n{Language.AccountCreated}{account.Number}");
        }

        public void ListAll()
        {
            Console.WriteLine($"\n{Language.ListAll}");
            if (_accounts.Count == 0)
            {
                Console.WriteLine(Language.NoAccounts);
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
            if (index < 0) { Console.WriteLine(Language.AccountNotFound); return; }
            _accounts[index] = account;
            DatabaseSqlite.Save(account);
            Console.WriteLine(Language.AccountUpdated);
        }

        public void Delete(int number)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine(Language.AccountNotFound); return; }
            _accounts.Remove(account);
            DatabaseSqlite.Delete(number);
            Console.WriteLine(Language.AccountDeleted);
        }

        public bool Withdraw(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine(Language.AccountNotFound); return false; }
            bool success = account.Withdraw(amount);
            if (success) DatabaseSqlite.Save(account);
            Console.WriteLine(success ? Language.WithdrawSuccess : Language.InsufficientBalance);
            return success;
        }

        public bool Deposit(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine(Language.AccountNotFound); return false; }
            bool success = account.Deposit(amount);
            if (success) DatabaseSqlite.Save(account);
            Console.WriteLine(success ? Language.DepositSuccess : Language.InvalidAmount);
            return success;
        }

        public bool Transfer(int originNumber, int destinyNumber, decimal amount)
        {
            var origin = FindByNumber(originNumber);
            var destiny = FindByNumber(destinyNumber);
            if (origin == null || destiny == null)
            { Console.WriteLine(Language.AccountNotFound); return false; }
            if (!origin.Withdraw(amount))
            { Console.WriteLine(Language.InsufficientBalance); return false; }
            destiny.Deposit(amount);
            DatabaseSqlite.Save(origin);
            DatabaseSqlite.Save(destiny);
            Console.WriteLine(Language.TransferSuccess);
            return true;
        }
    }
}