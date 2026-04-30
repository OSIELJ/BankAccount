using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class SavingsAccount : Account
    {
        // Attributes
        public int Anniversary { get; set; }

        // Constructor
        public SavingsAccount(string owner, decimal initialBalance, int anniversary = 30)
            : base(owner, initialBalance, 2)
        {
            Anniversary = anniversary;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Anniversary: {Anniversary} days";
        }
    }
}
