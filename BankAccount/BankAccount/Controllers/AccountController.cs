using BankAccount.Models;
using BankAccount.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BankAccount.Controllers
{
    public class AccountController : IAccountRepository
    {
        private List<Account> _accounts = new List<Account>();

        public void Create(Account account)
        {
            _accounts.Add(account);
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
            Console.WriteLine("Account updated successfully!");
        }

        public void Delete(int number)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return; }
            _accounts.Remove(account);
            Console.WriteLine("Account deleted successfully!");
        }

        public bool Withdraw(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return false; }
            bool success = account.Withdraw(amount);
            Console.WriteLine(success ? "Withdraw successful!" : "Insufficient balance.");
            return success;
        }

        public bool Deposit(int number, decimal amount)
        {
            var account = FindByNumber(number);
            if (account == null) { Console.WriteLine("Account not found."); return false; }
            bool success = account.Deposit(amount);
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
            Console.WriteLine("Transfer successful!");
            return true;
        }
    }
}
