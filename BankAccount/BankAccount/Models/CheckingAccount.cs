using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class CheckingAccount : Account
    {
        // Attributes
        public decimal Limit { get; set; }

        // Constructor
        public CheckingAccount(string owner, decimal initialBalance, decimal limit = 1000)
            : base(owner, initialBalance, 1)
        {
            Limit = limit;
        }

        // Override Withdraw to use limit
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > (Balance + Limit)) return false;
            Balance -= amount;
            return true;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Limit: {Limit:C}";
        }
    }
}
