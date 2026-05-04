using BankAccount.Utils;

namespace BankAccount.Models
{
    public class CheckingAccount : Account
    {
        public decimal Limit { get; set; }

        public CheckingAccount(string owner, decimal initialBalance, decimal limit = 1000)
            : base(owner, initialBalance, 1)
        {
            Limit = limit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > (Balance + Limit)) return false;
            Balance -= amount;
            return true;
        }

        public override string ToString()
        {
            return Language.Current == AppLanguage.PTBR
                ? $"{base.ToString()} | Limite: {Limit:C}"
                : $"{base.ToString()} | Limit: {Limit:C}";
        }
    }
}