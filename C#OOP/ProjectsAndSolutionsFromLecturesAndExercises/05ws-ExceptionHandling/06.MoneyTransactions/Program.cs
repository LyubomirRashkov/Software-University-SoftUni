using System;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    public class Program
    {
        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, decimal> balancesByAccount = new Dictionary<int, decimal>();

            foreach (string element in inputLine)
            {
                string[] currentInfo = element.Split('-', StringSplitOptions.RemoveEmptyEntries);

                int account = int.Parse(currentInfo[0]);
                decimal balance = decimal.Parse(currentInfo[1]);

                if (!balancesByAccount.ContainsKey(account))
                {
                    balancesByAccount.Add(account, balance);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[0];
                int account = int.Parse(inputInfo[1]);
                decimal sum = decimal.Parse(inputInfo[2]);

                try
                {
                    ProcessCommand(balancesByAccount, command, account, sum);
                    Console.WriteLine($"Account {account} has new balance: {balancesByAccount[account]:F2}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid command!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static void ProcessCommand(Dictionary<int, decimal> balancesByAccount, string command, int account, decimal sum)
        {
            if (command == "Deposit")
            {
                if (!balancesByAccount.ContainsKey(account))
                {
                    throw new KeyNotFoundException();
                }

                balancesByAccount[account] += sum;
            }
            else if (command == "Withdraw")
            {
                if (!balancesByAccount.ContainsKey(account))
                {
                    throw new KeyNotFoundException();
                }

                if (balancesByAccount[account] < sum)
                {
                    throw new ArgumentException();
                }

                balancesByAccount[account] -= sum;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
