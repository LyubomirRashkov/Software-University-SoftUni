using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private readonly Dictionary<string, Wallet> walletsById;
        private readonly Dictionary<string, User> usersById;

        public BitcoinWalletManager()
        {
            this.walletsById = new Dictionary<string, Wallet>();
            this.usersById = new Dictionary<string, User>();
        }

        public void CreateUser(User user) => this.usersById.Add(user.Id, user);

        public void CreateWallet(Wallet wallet)
        {
            this.walletsById.Add(wallet.Id, wallet);

            this.usersById[wallet.UserId].Wallets.Add(wallet);

            this.usersById[wallet.UserId].Transactions.AddRange(wallet.Transactions);
        }

        public bool ContainsUser(User user) => this.usersById.ContainsKey(user.Id);

        public bool ContainsWallet(Wallet wallet) => this.walletsById.ContainsKey(wallet.Id);

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
            => this.walletsById.Values
               .Where(w => w.UserId == userId);

        public void PerformTransaction(Transaction transaction)
        {
            if (!this.walletsById.ContainsKey(transaction.SenderWalletId)
                || !this.walletsById.ContainsKey(transaction.ReceiverWalletId)
                || this.walletsById[transaction.SenderWalletId].Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            this.walletsById[transaction.SenderWalletId].Balance -= transaction.Amount;

            this.walletsById[transaction.SenderWalletId].Transactions.Add(transaction);

            this.walletsById[transaction.ReceiverWalletId].Balance += transaction.Amount;

            this.walletsById[transaction.ReceiverWalletId].Transactions.Add(transaction);

            this.usersById[this.walletsById[transaction.SenderWalletId].UserId].Transactions.Add(transaction);

            this.usersById[this.walletsById[transaction.ReceiverWalletId].UserId].Transactions.Add(transaction);
		}

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            if (!this.usersById.ContainsKey(userId))
            {
                return Enumerable.Empty<Transaction>();
            }

            return this.usersById[userId].Transactions;
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
            => this.walletsById.Values
               .OrderByDescending(w => w.Balance);

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
            => this.usersById.Values
               .OrderByDescending(u => u.Wallets.Sum(w => w.Balance));

        public IEnumerable<User> GetUsersByTransactionCount()
            => this.usersById.Values
               .OrderByDescending(u => u.Transactions.Count);
    }
}