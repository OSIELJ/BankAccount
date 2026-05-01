using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Repositories
{
    public interface IAccountRepository
    {
        void Create(Account account);
        void ListAll();
        Account? FindByNumber(int number);
        void Update(Account account);
        void Delete(int number);
        bool Withdraw(int number, decimal amount);
        bool Deposit(int number, decimal amount);
        bool Transfer(int originNumber, int destinyNumber, decimal amount);
    }
}
