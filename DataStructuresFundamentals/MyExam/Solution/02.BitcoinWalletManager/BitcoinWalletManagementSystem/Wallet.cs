using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    public class Wallet
    {
        public Wallet()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public long Balance { get; set; }

        public HashSet<Transaction> Transactions { get; set; }
    }
}