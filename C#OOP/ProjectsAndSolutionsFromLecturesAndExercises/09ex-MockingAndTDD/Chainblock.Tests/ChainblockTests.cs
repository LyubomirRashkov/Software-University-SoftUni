using Chainblock.Contracts;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionWithIdAlreadyExists()
        {
            int id = 1;

            ITransaction transaction1 = new Transaction
            {
                Id = id,
                Amount = 100,
                From = "Sender1",
                To = "Receiver1",
                Status = TransactionStatus.Successfull
            };

            this.chainblock.Add(transaction1);

            ITransaction transaction2 = new Transaction
            {
                Id = id,
                Amount = 150,
                From = "Sender2",
                To = "Receiver2",
                Status = TransactionStatus.Failed
            };

            Assert.That(() => this.chainblock.Add(transaction2), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_AddsTransactionToChainblock_WhenTransactionIdIsValid()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            int searchingId = 1;

            Assert.That(this.chainblock.Contains(searchingId), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            Assert.That(this.chainblock.Contains(transaction), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionIdExistsButOtherPropertiesDoNotMatch()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount + 100,
                From = "Fake" + transaction.From,
                To = "Fake" + transaction.To,
                Status = TransactionStatus.Failed
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue_WhenTransactionMatchesChainblockTransaction()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                From = transaction.From,
                To = transaction.To,
                Status = transaction.Status
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.True);
        }

        [Test]
        public void Count_ReturnsZero_WhenChainblockIsEmpty()
        {
            Assert.That(this.chainblock.Count, Is.Zero);
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            int searchingId = transaction.Id + 100;

            Assert.That(() => this.chainblock.ChangeTransactionStatus(searchingId, TransactionStatus.Failed),
                              Throws.ArgumentException);
        }

        [Test]
        public void ChangeTransactionStatus_ChangesTransactionStatus_WhenTransactionIdExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            TransactionStatus newStatus = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(transaction.Id, newStatus);

            Assert.That(transaction.Status, Is.EqualTo(newStatus));
        }

        [Test]
        public void RemoveTransactionById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            int searchingId = transaction.Id + 100;

            Assert.That(() => this.chainblock.RemoveTransactionById(searchingId), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveTransactionById_RemovesTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            int countOfTransactionsBeforeRemoving = this.chainblock.Count;

            this.chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(countOfTransactionsBeforeRemoving - 1, Is.EqualTo(this.chainblock.Count));
            Assert.That(this.chainblock.Contains(transaction.Id), Is.False);
        }

        [Test]
        public void GetById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            int searchingId = transaction.Id + 100;

            Assert.That(() => this.chainblock.GetById(searchingId), Throws.InvalidOperationException);
        }

        [Test]
        public void GetById_ReturnsExpectedTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = this.chainblock.GetById(transaction.Id);

            Assert.That(transaction, Is.EqualTo(searchingTransaction));
        }

        [Test]
        public void GetByTransactionStatus_ThrowsException_WhenThereAreNoTransactionsWithTheGivenStatus()
        {
            this.AddThreeTransactionsWithDifferentStatus();

            Assert.That(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized),
                              Throws.InvalidOperationException);
        }

        [Test]
        public void GetByTransactionStatus_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenStatus()
        {
            this.AddBulkOfTransactions();

            TransactionStatus filterStatus = TransactionStatus.Successfull;

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.Status == filterStatus)
                                                     .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = this.chainblock.GetByTransactionStatus(filterStatus);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWithTheGivenStatus()
        {
            this.AddBulkOfTransactions();

            TransactionStatus filterStatus = TransactionStatus.Successfull;

            IEnumerable<ITransaction> result = this.chainblock.GetByTransactionStatus(filterStatus);

            double previousAmount = double.MaxValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.Status, Is.EqualTo(filterStatus));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                previousAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsException_WhenThereAreNoTransactionsWithTheGivenStatus()
        {
            this.AddThreeTransactionsWithDifferentStatus();

            Assert.That(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized),
                              Throws.InvalidOperationException);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenStatus()
        {
            this.AddBulkOfTransactions();

            TransactionStatus status = TransactionStatus.Successfull;

            IEnumerable<string> expected = this.chainblock
                                               .Where(t => t.Status == status)
                                               .OrderBy(t => t.Amount)
                                               .Select(t => t.From);

            IEnumerable<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(status);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsException_WhenThereAreNoTransactionsWithTheGivenStatus()
        {
            this.AddThreeTransactionsWithDifferentStatus();

            Assert.That(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized),
                              Throws.InvalidOperationException);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenStatus()
        {
            this.AddBulkOfTransactions();

            TransactionStatus status = TransactionStatus.Successfull;

            IEnumerable<string> expected = this.chainblock
                                               .Where(t => t.Status == status)
                                               .OrderBy(t => t.Amount)
                                               .Select(t => t.To);

            IEnumerable<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(status);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsSortedData()
        {
            this.AddBulkOfTransactions();

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .OrderByDescending(t => t.Amount)
                                                     .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsSortedData2()
        {
            this.AddBulkOfTransactions();

            IEnumerable<ITransaction> result = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            double previousAmount = double.MaxValue;
            int previousId = this.chainblock.Min(t => t.Id);

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                if (transaction.Amount == previousAmount)
                {
                    Assert.That(transaction.Id, Is.GreaterThan(previousId));
                }

                previousAmount = transaction.Amount;
                previousId = transaction.Id;
            }
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_WhenThereAreNoTransactionsWithTheGivenSender()
        {
            this.AddBulkOfTransactions();

            string filterSender = "FakeSender";

            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending(filterSender),
                              Throws.InvalidOperationException);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenSender()
        {
            this.AddBulkOfTransactions();

            string sender = "Sender";

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.From == sender)
                                                     .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending(sender);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWithTheGivenSender()
        {
            this.AddBulkOfTransactions();

            string sender = "Sender";

            IEnumerable<ITransaction> result = this.chainblock.GetBySenderOrderedByAmountDescending(sender);

            double previousAmount = double.MaxValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.From, Is.EqualTo(sender));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                previousAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsException_WhenThereAreNoTransactionsWithTheGivenReceiver()
        {
            this.AddBulkOfTransactions();

            string fakeReceiver = "FakeReceiver";

            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById(fakeReceiver), Throws.InvalidOperationException);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenReceiver()
        {
            this.AddBulkOfTransactions();

            string receiver = "Receiver";

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.To == receiver)
                                                     .OrderBy(t => t.Amount)
                                                     .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actual = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWithTheGivenReceiver()
        {
            this.AddBulkOfTransactions();

            string receiver = "Receiver";

            IEnumerable<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver);

            double previousAmount = double.MinValue;
            int previousId = int.MinValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.GreaterThanOrEqualTo(previousAmount));

                if (transaction.Amount == previousAmount)
                {
                    Assert.That(transaction.Id, Is.GreaterThan(previousId));
                }

                previousAmount = transaction.Amount;
                previousId = transaction.Id;
            }
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized, 100)]
        [TestCase(TransactionStatus.Successfull, double.MinValue)]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenThereAreNoTransactionsWithTheGivenCriteria(TransactionStatus status, double amount)
        {
            this.AddThreeTransactionsWithDifferentStatus();

            IEnumerable<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);

            Assert.That(result, Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            TransactionStatus status = this.chainblock.LastOrDefault().Status;
            double amount = this.chainblock.LastOrDefault().Amount / 2;

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.Status == status && t.Amount <= amount)
                                                     .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            TransactionStatus status = this.chainblock.LastOrDefault().Status;
            double amount = this.chainblock.LastOrDefault().Amount / 2;

            IEnumerable<ITransaction> result = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);

            double previousAmount = double.MaxValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.Status, Is.EqualTo(status));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(amount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                previousAmount = transaction.Amount;
            }
        }

        [Test]
        [TestCase("FakeSender", double.MinValue)]
        [TestCase("Sender", double.MaxValue)]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenThereAreNoTransactionsWithTheGivenCriteria
                    (string sender, double amount)
        {
            this.AddBulkOfTransactions();

            Assert.That(() => this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount),
                              Throws.InvalidOperationException);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            string sender = this.chainblock.LastOrDefault().From;
            double amount = this.chainblock.LastOrDefault().Amount / 2;

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.From == sender && t.Amount > amount)
                                                     .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            string sender = this.chainblock.LastOrDefault().From;
            double amount = this.chainblock.LastOrDefault().Amount / 2;

            IEnumerable<ITransaction> result = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);

            double previousAmount = double.MaxValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.From, Is.EqualTo(sender));
                Assert.That(transaction.Amount, Is.GreaterThan(amount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                previousAmount = transaction.Amount;
            }
        }

        [Test]
        [TestCase("FakeReceiver", 100, 10_000)]
        [TestCase("Receiver", 150, 10_1000)]
        [TestCase("Receiver", 50, 100)]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenThereAreNoTransactionsWithTheGivenCriteria(string receiver, double low, double high)
        {
            this.AddBulkOfTransactions();

            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange(receiver, low, high), Throws.InvalidOperationException);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsFilteredAndSortedData_WhenThereAreTransactionsWitTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            string receiver = this.chainblock.LastOrDefault().To;
            double low = this.chainblock.LastOrDefault().Amount / 50;
            double high = this.chainblock.LastOrDefault().Amount;

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.To == receiver && t.Amount >= low && t.Amount < high)
                                                     .OrderByDescending(t => t.Amount)
                                                     .ThenBy(t => t.Id);

            IEnumerable<ITransaction> actual = this.chainblock.GetByReceiverAndAmountRange(receiver, low, high);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsFilteredAndSortedData2_WhenThereAreTransactionsWitTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            string receiver = this.chainblock.LastOrDefault().To;
            double low = this.chainblock.LastOrDefault().Amount / 50;
            double high = this.chainblock.LastOrDefault().Amount;

            IEnumerable<ITransaction> result = this.chainblock.GetByReceiverAndAmountRange(receiver, low, high);

            double previousAmount = double.MaxValue;
            int previousId = int.MinValue;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.GreaterThanOrEqualTo(low));
                Assert.That(transaction.Amount, Is.LessThan(high));

                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(previousAmount));

                if (transaction.Amount == previousAmount)
                {
                    Assert.That(transaction.Id, Is.GreaterThan(previousId));
                }

                previousAmount = transaction.Amount;
                previousId = transaction.Id;
            }
        }

        [Test]
        [TestCase(100_000, 1_000_000)]
        [TestCase(-1000, -100)]
        public void GetAllInAmountRange_ReturnsAnEmptyCollection_WhenThereAreNoTransactionsWithTheGivenCriteria
                    (double low, double high)
        {
            this.AddBulkOfTransactions();

            IEnumerable<ITransaction> result = this.chainblock.GetAllInAmountRange(low, high);

            Assert.That(result, Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetAllInAmountRange_ReturnsFilteredData_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            double low = this.chainblock.FirstOrDefault().Amount * 10;
            double high = this.chainblock.LastOrDefault().Amount / 10;

            IEnumerable<ITransaction> expected = this.chainblock
                                                     .Where(t => t.Amount >= low && t.Amount <= high);

            IEnumerable<ITransaction> actual = this.chainblock.GetAllInAmountRange(low, high);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void GetAllInAmountRange_ReturnsFilteredData2_WhenThereAreTransactionsWithTheGivenCriteria()
        {
            this.AddBulkOfTransactions();

            double low = this.chainblock.FirstOrDefault().Amount * 10;
            double high = this.chainblock.LastOrDefault().Amount / 10;

            IEnumerable<ITransaction> result = this.chainblock.GetAllInAmountRange(low, high);

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.Amount, Is.GreaterThanOrEqualTo(low));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(high));
            }
        }

        private ITransaction CreateSimpleTransaction()
        {
            return new Transaction
            {
                Id = 1,
                Amount = 100,
                From = "Sender",
                To = "Receiver",
                Status = TransactionStatus.Successfull
            };
        }

        private void AddThreeTransactionsWithDifferentStatus()
        {
            ITransaction transaction1 = new Transaction
            {
                Id = 1,
                Amount = 100,
                From = "Sender",
                To = "Receiver",
                Status = TransactionStatus.Successfull
            };

            this.chainblock.Add(transaction1);

            ITransaction transaction2 = new Transaction
            {
                Id = 2,
                Amount = 100,
                From = "Sender",
                To = "Receiver",
                Status = TransactionStatus.Failed
            };

            this.chainblock.Add(transaction2);

            ITransaction transaction3 = new Transaction
            {
                Id = 3,
                Amount = 100,
                From = "Sender",
                To = "Receiver",
                Status = TransactionStatus.Aborted
            };

            this.chainblock.Add(transaction3);
        }

        private void AddBulkOfTransactions()
        {
            int numberOfTransactions = 100;

            for (int i = 1; i <= numberOfTransactions; i++)
            {
                TransactionStatus status = TransactionStatus.Successfull;
                double amount = 100;
                string from = "Sender100";
                string to = "Receiver";

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Failed;
                    amount = 100 * i;
                    from = "Sender";
                    to = "Receiver100";
                }
                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Aborted;
                    amount = 100 * 2 * i;
                    from = "Sender200";
                    to = "Receiver200";
                }
                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                    amount = 100 * 3 * i;
                    from = "Sender300";
                    to = "Receiver300";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Amount = amount,
                    From = from,
                    To = to,
                    Status = status
                };

                this.chainblock.Add(transaction);
            }
        }
    }
}
