using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    // Bank Account class
    public class BankAccount : IBankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialAmount)
        {
            balance = initialAmount;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
    }
}
