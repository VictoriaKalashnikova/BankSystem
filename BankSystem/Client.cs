using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    // Client class
    public class Client
    {
        public string? Id { get; }
        public List<IBankAccount> Accounts { get; }

        public Client(string? clientId)
        {
            Id = clientId;
            Accounts = new List<IBankAccount>();
        }
    }
}
