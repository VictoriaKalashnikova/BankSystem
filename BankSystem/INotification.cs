using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    // Notification interface
    public interface INotification
    {
        void NotifyTransaction(string? clientId, decimal amount);
        void NotifyBalanceChange(string? clientId, decimal newBalance);
    }
}
