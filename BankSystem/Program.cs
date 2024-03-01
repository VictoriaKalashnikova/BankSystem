namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bankingSystem = new BankingSystem();
            while (true)
            {
                Console.WriteLine("Enter command (create, close, deposit, withdraw, balance, test, exit):");
                string? command = Console.ReadLine();

                switch (command)
                {
                    case "create":
                        Console.WriteLine("Enter client ID:");
                        string? clientId = Console.ReadLine();
                        bankingSystem.CreateAccount(clientId);
                        break;

                    case "close":
                        Console.WriteLine("Enter client ID:");
                        clientId = Console.ReadLine();
                        bankingSystem.CloseAccount(clientId);
                        break;

                    case "deposit":
                        Console.WriteLine("Enter client ID:");
                        clientId = Console.ReadLine();
                        Console.WriteLine("Enter amount to deposit:");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        if (bankingSystem.PerformTransaction(clientId, depositAmount))
                            bankingSystem.NotifyBalanceChange(clientId, bankingSystem.Clients[clientId].Accounts[0].GetBalance());
                        break;

                    case "withdraw":
                        Console.WriteLine("Enter client ID:");
                        clientId = Console.ReadLine();
                        Console.WriteLine("Enter amount to withdraw:");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        if (bankingSystem.PerformTransaction(clientId, -withdrawAmount))
                            bankingSystem.NotifyBalanceChange(clientId, bankingSystem.Clients[clientId].Accounts[0].GetBalance());
                        break;

                    case "balance":
                        Console.WriteLine("Enter client ID:");
                        clientId = Console.ReadLine();
                        Console.WriteLine($"Balance for client {clientId}: {bankingSystem.Clients[clientId].Accounts[0].GetBalance()}");
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
    }
}
