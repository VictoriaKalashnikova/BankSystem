using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    // Account Operations interface
    public interface IAccountOperations
    {
        void CreateAccount(string? clientId);
        void CloseAccount(string? clientId);
        bool PerformTransaction(string? clientId, decimal amount);
    }
}
