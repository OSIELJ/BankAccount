using BankAccount.Utils;

namespace BankAccount.Models
{
    public class SavingsAccount : Account
    {
        public int Anniversary { get; set; }

        public SavingsAccount(string owner, decimal initialBalance, int anniversary = 30, string agency = "001", string password = "1234")
            : base(owner, initialBalance, 2, agency, password)
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