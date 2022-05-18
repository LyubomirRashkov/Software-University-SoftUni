using NUnit.Framework;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private const string ItemOwner = "Some owner";
        private const string ItemId = "Some Id";
        private const string Cell = "A1";
        private const string InvalidCell = "Z500";
        private const string Item2Owner = "Some owner 2";
        private const string Item2Id = "Some Id 2";

        private BankVault bankVault;
        private Item item;
        private Item item2;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
            this.item = new Item(ItemOwner, ItemId);
            this.item2 = new Item(Item2Owner, Item2Id);
        }

        [Test]
        public void Constructor_WorksCorrectly()
        {
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddItem_ThrowsException_WhenTheGivenCellIsInvalid()
        {
            Assert.That(() => this.bankVault.AddItem(InvalidCell, this.item), Throws.ArgumentException);
        }

        [Test]
        public void AddItem_WorksCorrectly_WhenDataIsValid()
        {
            Dictionary<string, Item> expectedCollection = new Dictionary<string, Item>
            {
                {"A1", this.item},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null}
            };

            string expectedResult = $"Item:{ItemId} saved successfully!";
            string actualResult = this.bankVault.AddItem(Cell, this.item);

            Assert.That(expectedCollection, Is.EquivalentTo(this.bankVault.VaultCells));
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void AddItem_ThrowsException_WhenTheGivenCellHasValueDifferentFromNull()
        {
            this.bankVault.AddItem(Cell, this.item);

            Assert.That(() => this.bankVault.AddItem(Cell, this.item2), Throws.ArgumentException);
        }

        [Test]
        public void AddItem_ThrowsException_WhenThereIsACellWithTheGivenValue()
        {
            this.bankVault.AddItem(Cell, this.item);

            string newCell = "B1";

            Assert.That(() => this.bankVault.AddItem(newCell, this.item), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenTheGivenCellIsInvalid()
        {
            Assert.That(() => this.bankVault.RemoveItem(InvalidCell, this.item), Throws.ArgumentException);
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenTheGivenItemIsNotInTheGivenCell()
        {
            this.bankVault.AddItem(Cell, this.item);

            Assert.That(() => this.bankVault.RemoveItem(Cell, this.item2), Throws.ArgumentException);
        }

        [Test]
        public void RemoveItem_WorksCorrectly_WhenDataIsValid()
        {
            this.bankVault.AddItem(Cell, this.item);

            Dictionary<string, Item> expectedCollection = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null}
            };

            string expectedResult = $"Remove item:{ItemId} successfully!";
            string actualResult = this.bankVault.RemoveItem(Cell, this.item);

            Assert.That(expectedCollection, Is.EquivalentTo(this.bankVault.VaultCells));
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}