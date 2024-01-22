using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManager
{
    public class WalletManager : IWalletManager
    {
        private readonly Dictionary<string, Transaction> pendingTransactionsByHash;

        private readonly Dictionary<string, Transaction> executedTransactionsByHash;

        private readonly Dictionary<string, Dictionary<string, Transaction>> collectionOfExecutedTransactionsByUser;

        private readonly Dictionary<string, SortedSet<Transaction>> sortedCollectionOfPendingTransactionsByUser;

        public WalletManager()
        {
            this.pendingTransactionsByHash = new Dictionary<string, Transaction>();
            this.executedTransactionsByHash = new Dictionary<string, Transaction>();
            this.collectionOfExecutedTransactionsByUser = new Dictionary<string, Dictionary<string, Transaction>>();
            this.sortedCollectionOfPendingTransactionsByUser = new Dictionary<string, SortedSet<Transaction>>();
        }

        public void AddTransaction(Transaction transaction)
        {
            this.pendingTransactionsByHash.Add(transaction.Hash, transaction);

            if (!this.sortedCollectionOfPendingTransactionsByUser.ContainsKey(transaction.From))
            {
                this.sortedCollectionOfPendingTransactionsByUser.Add(
                    transaction.From, 
                    new SortedSet<Transaction>(Comparer<Transaction>.Create((f, s) => f.Nonce.CompareTo(s.Nonce))));
            }
            
            this.sortedCollectionOfPendingTransactionsByUser[transaction.From].Add(transaction);
        }

        public Transaction BroadcastTransaction(string txHash)
        {
            this.ValidateTransactionIsPending(txHash);

            Transaction transaction = this.pendingTransactionsByHash[txHash];

            this.pendingTransactionsByHash.Remove(txHash);

            this.sortedCollectionOfPendingTransactionsByUser[transaction.From].Remove(transaction);

            this.executedTransactionsByHash.Add(txHash, transaction);

            if (!this.collectionOfExecutedTransactionsByUser.ContainsKey(transaction.From))
            {
                this.collectionOfExecutedTransactionsByUser.Add(transaction.From, new Dictionary<string, Transaction>());
            }

            this.collectionOfExecutedTransactionsByUser[transaction.From].Add(txHash, transaction);

            return transaction;
        }

		public Transaction CancelTransaction(string txHash)
        {
			if (!this.pendingTransactionsByHash.ContainsKey(txHash))
			{
				throw new ArgumentException();
			}

			Transaction transaction = this.pendingTransactionsByHash[txHash];

			this.pendingTransactionsByHash.Remove(txHash);
            
            this.sortedCollectionOfPendingTransactionsByUser[transaction.From].Remove(transaction);

			return transaction;
		}

        public bool Contains(string txHash) => this.pendingTransactionsByHash.ContainsKey(txHash);

        public int GetEarliestNonceByUser(string user)
            => this.sortedCollectionOfPendingTransactionsByUser[user].FirstOrDefault() != null 
               ? this.sortedCollectionOfPendingTransactionsByUser[user].FirstOrDefault().Nonce
               : 0;

        public IEnumerable<Transaction> GetHistoryTransactionsByUser(string user)
            => this.collectionOfExecutedTransactionsByUser[user].Values;

        public IEnumerable<Transaction> GetPendingTransactionsByUser(string user)
            => this.sortedCollectionOfPendingTransactionsByUser[user];

		private void ValidateTransactionIsPending(string txHash)
		{
			if (!this.pendingTransactionsByHash.ContainsKey(txHash))
			{
				throw new ArgumentException();
			}
		}
    }
}
