using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankingSystem : IAccountOperations, INotification
    {
        internal Dictionary<string?, Client> Clients;

        public BankingSystem()
        {
            Clients = new Dictionary<string, Client>()!;
        }

        public void CreateAccount(string? clientId)
        {
            if (Clients.ContainsKey(clientId))
            {
                Console.WriteLine("Account creation failed. Client already exists.");
                return;
            }

            Client client = new Client(clientId);
            IBankAccount account = new BankAccount(0); // Создаем новый банковский счет с начальным балансом 0
            client.Accounts.Add(account); // Добавляем созданный счет в список аккаунтов клиента
            Clients.Add(clientId, client);
            Console.WriteLine($"Account created successfully for client: {clientId}");
        }

        public void CloseAccount(string? clientId)
        {
            if (Clients.ContainsKey(clientId))
            {
                Clients.Remove(clientId);
                Console.WriteLine($"Account closed successfully for client: {clientId}");
            }
            else
            {
                Console.WriteLine("Account closure failed. Client does not exist.");
            }
        }

        public bool PerformTransaction(string? clientId, decimal amount)
        {
            if (!Clients.ContainsKey(clientId))
            {
                Console.WriteLine("Transaction failed. Client does not exist.");
                return false;
            }

            Client client = Clients[clientId];
            if (client.Accounts.Count == 0)
            {
                Console.WriteLine("Transaction failed. No account found for the client.");
                return false;
            }

            IBankAccount account = client.Accounts[0]; // Предполагаем, что у клиента есть только один счет для простоты
            if (amount < 0) // Используйте отрицательное значение для снятия средств
            {
                decimal withdrawAmount = -amount; // Преобразуем в положительное значение для понимания
                if (account.Withdraw(withdrawAmount))
                {
                    NotifyTransaction(clientId, amount);
                    return true;
                }
                else
                {
                    Console.WriteLine("Transaction failed. Insufficient balance.");
                    return false;
                }
            }
            else if (amount > 0) // Положительное значение для пополнения счета
            {
                account.Deposit(amount);
                NotifyTransaction(clientId, amount);
                return true;
            }
            else
            {
                Console.WriteLine("Transaction failed. Invalid amount.");
                return false;
            }
        }


        public bool PerformTransaction(string? senderId, string? recipientId, decimal amount)
        {
            if (Clients.ContainsKey(senderId) && Clients.ContainsKey(recipientId))
            {
                Client sender = Clients[senderId];
                Client recipient = Clients[recipientId];

                if (sender.Accounts.Count > 0 && recipient.Accounts.Count > 0)
                {
                    IBankAccount senderAccount = sender.Accounts[0];
                    IBankAccount recipientAccount = recipient.Accounts[0];

                    if (senderAccount.Withdraw(amount))
                    {
                        recipientAccount.Deposit(amount);
                        NotifyTransaction(senderId, -amount);
                        NotifyTransaction(recipientId, amount);
                        return true;
                    }

                    Console.WriteLine("Transaction failed. Insufficient balance.");
                    return false;
                }

                Console.WriteLine("Transaction failed. No account found for one or both clients.");
                return false;
            }

            Console.WriteLine("Transaction failed. One or both clients do not exist.");
            return false;
        }

        public void NotifyTransaction(string? clientId, decimal amount)
        {
            Console.WriteLine($"Transaction successful. Amount: {amount}, Client ID: {clientId}");
        }

        public void NotifyBalanceChange(string? clientId, decimal newBalance)
        {
            Console.WriteLine($"Balance changed for client: {clientId}. New balance: {newBalance}");
        }

        public decimal GetBalance(string? clientId)
        {
            if (Clients.ContainsKey(clientId))
            {
                Client client = Clients[clientId];
                if (client.Accounts.Count > 0)
                {
                    IBankAccount account = client.Accounts[0]; // Assuming only one account per client for simplicity
                    return account.GetBalance();
                }
            }
            Console.WriteLine("Balance retrieval failed. Client or account not found.");
            return 0;
        }
    }
}
