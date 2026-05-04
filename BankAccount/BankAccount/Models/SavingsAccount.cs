using BankAccount.Utils;

namespace BankAccount.Models
{
    public class SavingsAccount : Account
    {
        public int Anniversary { get; set; }

        public SavingsAccount(string owner, decimal initialBalance, int anniversary = 30)
            : base(owner, initialBalance, 2)
        {
            Anniversary = anniversary;
        }

        public override string ToString()
        {
            return Language.Current == AppLanguage.PTBR
                ? $"{base.ToString()} | Aniversário: {Anniversary} dias"
                : $"{base.ToString()} | Anniversary: {Anniversary} days";
        }
    }
}