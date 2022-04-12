namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int Capacity = 16;

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < Capacity; i++)
            {
                this.database.Add(i);
            }

            Assert.That(() => this.database.Add(Capacity), Throws.InvalidOperationException,
                                                                    "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        public void Add_IncreasesCountByOneWhenElementIsAdded(int countOfElementsToAdd)
        {
            for (int i = 0; i < countOfElementsToAdd; i++)
            {
                this.database.Add(i);
            }

            Assert.That(this.database.Count, Is.EqualTo(countOfElementsToAdd));
        }

        [Test]
        public void Add_AddsTheElementToDatabase()
        {
            int element = 50;
            this.database.Add(element);

            int[] elementsOfDatabase = this.database.Fetch();

            CollectionAssert.Contains(elementsOfDatabase, element);
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException, "The collection is empty!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void Remove_DecreasesDatabaseCount_WhenRemovingIsSuccessfull(int countOfElementsToRemove)
        {
            int countOfElementsToAdd = 10;

            for (int i = 0; i < countOfElementsToAdd; i++)
            {
                this.database.Add(i);
            }

            int countOfElementsBeforeRemoving = this.database.Count;

            for (int i = 0; i < countOfElementsToRemove; i++)
            {
                this.database.Remove();
            }

            int countOfElementsAfterRemoving = this.database.Count;

            Assert.That(countOfElementsBeforeRemoving, Is.EqualTo(countOfElementsAfterRemoving + countOfElementsToRemove));
        }

        [Test]
        public void Remove_RemovesTheLastElementFromDatabase()
        {
            int lastElement = 50;

            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(lastElement);

            this.database.Remove();

            int[] elementsOfDatabase = this.database.Fetch();

            CollectionAssert.DoesNotContain(elementsOfDatabase, lastElement);
        }

        [Test]
        public void Fetch_ReturnsDatabaseCopyInsteadOfReference()
        {
            int[] firstCopy = this.database.Fetch();

            this.database.Add(1);

            int[] secondCopy = this.database.Fetch();

            CollectionAssert.AreNotEqual(firstCopy, secondCopy);
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] initialElements = new int[] { 1, 2, 3 };

            this.database = new Database(initialElements);

            int[] elementsInDatabase = this.database.Fetch();

            CollectionAssert.AreEqual(elementsInDatabase, initialElements);
        }

        [Test]
        public void Ctor_SetsTheCountOfDataBaseToTheArgumentArrayLength()
        {
            int[] initialElements = new int[] { 1, 2, 3 };

            this.database = new Database(initialElements);

            Assert.That(this.database.Count, Is.EqualTo(initialElements.Length));
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            int[] initialElements = new int[Capacity + 1];

            for (int i = 0; i < initialElements.Length; i++)
            {
                initialElements[i] = i;
            }

            Assert.That(() => this.database = new Database(initialElements), Throws.InvalidOperationException,
                                                                                      "Array's capacity must be exactly 16 integers!");
        }
    }
}
