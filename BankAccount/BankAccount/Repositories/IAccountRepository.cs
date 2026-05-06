using BankAccount.Models;

namespace BankAccount.Repositories
{
    // Contract that defines all operations available in the system
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