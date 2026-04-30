using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankAccount.Models
{
    public abstract class Account
    {
        // Attributes
        private static int _nextNumber = 1;

        public int Number { get; private set; }
        public string Owner { get; set; }
        public decimal Balance { get; protected set; }
        public int Type { get; protected set; } 

        // Constructor
        protected Account(string owner, decimal initialBalance, int type)
        {
            Number = _nextNumber++;
            Owner = owner;
            Balance = initialBalance;
            Type = type;
        }

        // Methods
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
            return $"Account: {Number} | Owner: {Owner} | " +
                   $"Balance: {Balance:C} | Type: {(Type == 1 ? "Checking" : "Savings")}";
        }
    }
}
