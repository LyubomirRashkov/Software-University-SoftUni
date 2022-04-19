using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionsById;

        public Chainblock()
        {
            this.transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactionsById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }

            this.transactionsById.Add(tx.Id, tx);
        }

        public bool Contains(int id)
        {
            return this.transactionsById.ContainsKey(id);
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.transactionsById.ContainsKey(tx.Id))
            {
                return false;
            }

            ITransaction transaction = this.transactionsById[tx.Id];

            return transaction.Amount == tx.Amount
                   && transaction.From == tx.From
                   && transaction.To == tx.To
                   && transaction.Status == tx.Status;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException();
            }

            this.transactionsById[id].Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            Validator<ITransaction>.DoesTransactionExist(this.transactionsById, id);

            this.transactionsById.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            Validator<ITransaction>.DoesTransactionExist(this.transactionsById, id);

            return this.transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> result = this.transactionsById
                .Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this.transactionsById
                                              .Values
                                              .Where(t => t.Status == status)
                                              .OrderBy(t => t.Amount)
                                              .Select(t => t.From);

            Validator<string>.IsCollectionEmpty(senders);

            return senders;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = this.transactionsById
                                                .Values
                                                .Where(t => t.Status == status)
                                                .OrderBy(t => t.Amount)
                                                .Select(t => t.To);

            Validator<string>.IsCollectionEmpty(receivers);

            return receivers;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactionsById
                       .Values
                       .OrderByDescending(t => t.Amount)
                       .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> result = this.transactionsById
                                                   .Values
                                                   .Where(t => t.From == sender)
                                                   .OrderByDescending(t => t.Amount);

            Validator<ITransaction>.IsCollectionEmpty(result);

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = this.transactionsById
                                                   .Values
                                                   .Where(t => t.To == receiver)
                                                   .OrderByDescending(t => t.Amount)
                                                   .ThenBy(t => t.Id);

            Validator<ITransaction>.IsCollectionEmpty(result);

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactionsById
                       .Values
                       .Where(t => t.Status == status && t.Amount <= amount)
                       .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> result = this.transactionsById
                                                   .Values
                                                   .Where(t => t.From == sender && t.Amount > amount)
                                                   .OrderByDescending(t => t.Amount);

            Validator<ITransaction>.IsCollectionEmpty(result);

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> result = this.transactionsById
                                                   .Values
                                                   .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                                                   .OrderByDescending(t => t.Amount)
                                                   .ThenBy(t => t.Id);

            Validator<ITransaction>.IsCollectionEmpty(result);

            return result;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactionsById
                       .Values
                       .Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (KeyValuePair<int, ITransaction> kvp in this.transactionsById)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
