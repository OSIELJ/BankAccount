using BankAccount.Utils;

namespace BankAccount.Models
{
    public abstract class Account
    {
        private static int _nextNumber = 1;

        public static void SetNextNumber(int next) => _nextNumber = next;
        public void SetNumber(int number) => Number = number;

        public int Number { get; private set; }
        public string Agency { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; protected set; }
        public int Type { get; protected set; }

        protected Account(string owner, decimal initialBalance, int type, string agency = "001")
        {
            Number = _nextNumber++;
            Agency = agency;
            Owner = owner;
            Balance = initialBalance;
            Type = type;
        }

        public virtual bool Deposit(decimal amount)
        {
            if (amount <= 0) return false;
            Balance += amount;
            return true;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance) return false;
            Balance -= amount;
            return true;
        }

        public override string ToString()
        {
            string type = Type == 1
                ? (Language.Current == AppLanguage.PTBR ? "Corrente" : "Checking")
                : (Language.Current == AppLanguage.PTBR ? "Poupança" : "Savings");

            return Language.Current == AppLanguage.PTBR
                ? $"Conta: {Number} | Agência: {Agency} | Titular: {Owner} | Saldo: {Balance:C} | Tipo: {type}"
                : $"Account: {Number} | Agency: {Agency} | Owner: {Owner} | Balance: {Balance:C} | Type: {type}";
        }
    }
}