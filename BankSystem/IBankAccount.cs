using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    // Bank Account interface
    public interface IBankAccount
    {
        decimal GetBalance();
        void Deposit(decimal amount);
        bool Withdraw(decimal amount);
    }
}
