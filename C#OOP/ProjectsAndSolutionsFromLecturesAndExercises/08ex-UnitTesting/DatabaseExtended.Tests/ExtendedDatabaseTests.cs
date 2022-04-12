namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class databaseTests
    {
        private const int Capacity = 16;

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void PersonCtor_CreatesAnInstanceWithInitialParameters()
        {
            long personId = 1;
            string personUsername = "Username";

            Person person = new Person(personId, personUsername);

            Assert.That(person.Id, Is.EqualTo(personId));
            Assert.That(person.UserName, Is.EqualTo(personUsername));
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < Capacity; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }

            Assert.That(() => this.database.Add(new Person(Capacity, $"Username{Capacity}")),
                        Throws.InvalidOperationException, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Add_ThrowsException_WhenAddingAPersonWithAlreadyUsedUsername()
        {
            string personUsername = "Username";

            long personOneId = 1;

            this.database.Add(new Person(personOneId, personUsername));

            long personTwoId = 2;

            Assert.That(() => this.database.Add(new Person(personTwoId, personUsername)),
                        Throws.InvalidOperationException, "There is already user with this username!");
        }

        [Test]
        public void Add_ThrowsException_WhenAddingAPersonWithAlreadyUsedId()
        {
            long personId = 0;

            string personOneUsername = "Username1";

            this.database.Add(new Person(personId, personOneUsername));

            string personTwoUsername = "Username2";

            Assert.That(() => this.database.Add(new Person(personId, personTwoUsername)),
                        Throws.InvalidOperationException, "There is already user with this Id!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        public void Add_IncreasesCountByOneOnEverySuccessfullAdding(int countOfElementToAdd)
        {
            int initialCount = this.database.Count;

            for (int i = 0; i < countOfElementToAdd; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }

            Assert.That(this.database.Count, Is.EqualTo(countOfElementToAdd));
        }

        [Test]
        public void Add_AddsElementToDatabase_WhenParametersAreValid()
        {
            long personId = 0;
            string personUsername = "Username";

            Person person = new Person(personId, personUsername);

            this.database.Add(person);

            Assert.That(Is.ReferenceEquals(this.database.FindByUsername(personUsername), person));
            Assert.That(Is.ReferenceEquals(this.database.FindById(personId), person));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] initialPeople = new Person[Capacity + 1];

            for (int i = 0; i < initialPeople.Length; i++)
            {
                initialPeople[i] = new Person(i, $"Username{i}");
            }

            Assert.That(() => this.database = new Database(initialPeople),
                        Throws.ArgumentException, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void Ctor_AddInitialPeopleToDatabase_WhenGivenArgumentIsValid()
        {
            Person[] initialPeople = new Person[Capacity];

            for (int i = 0; i < Capacity; i++)
            {
                initialPeople[i] = new Person(i, $"Username{i}");
            }

            this.database = new Database(initialPeople);

            Assert.That(this.database.Count, Is.EqualTo(initialPeople.Length));

            foreach (Person person in initialPeople)
            {
                Person dbPerson = this.database.FindByUsername(person.UserName);

                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void Remove_DecreasesCountByOne_EverytimeElementIsRemoved(int countOfElementsToRemove)
        {
            Person[] initialPeople = new Person[Capacity];

            for (int i = 0; i < initialPeople.Length; i++)
            {
                initialPeople[i] = new Person(i, $"Username{i}");
            }

            this.database = new Database(initialPeople);

            for (int i = 0; i < countOfElementsToRemove; i++)
            {
                this.database.Remove();
            }

            Assert.That(this.database.Count, Is.EqualTo(initialPeople.Length - countOfElementsToRemove));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_WhenGivenUsernameIsNullOrEmpty(string givenUsername)
        {
            Assert.That(() => this.database.FindByUsername(givenUsername),
                        Throws.ArgumentNullException, "Username parameter is null!");
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenThereIsNoPersonWithTheGivenUsername()
        {
            int countOfPeopleForAdding = 5;

            for (int i = 0; i < countOfPeopleForAdding; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }

            Assert.That(() => this.database.FindByUsername($"Username{countOfPeopleForAdding}"),
                        Throws.InvalidOperationException, "No user is present by this username!");
        }

        [Test]
        public void FindByUsername_ReturnsThePersonWithTheGivenUsername_WhenDatabaseContainsIt()
        {
            long personId = 0;
            string personUsername = "Username";

            Person person = new Person(personId, personUsername);

            this.database.Add(person);

            Person dbPerson = this.database.FindByUsername(personUsername);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void FindById_ThrowsException_WhenGivenIdIsLessThanZero()
        {
            long givenId = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(givenId), "Id should be a positive number!");
        }

        [Test]
        public void FindById_ThrowsException_WhenThereIsNoPersonWithTheGivenId()
        {
            int countOfPeopleForAdding = 5;

            for (int i = 0; i < countOfPeopleForAdding; i++)
            {
                this.database.Add(new Person(i, $"Username{i}"));
            }

            Assert.That(() => this.database.FindById(countOfPeopleForAdding),
                        Throws.InvalidOperationException, "No user is present by this ID!");
        }

        [Test]
        public void FindById_ReturnsThePersonWithTheGivenId_WhenDatabaseContainsIt()
        {
            long personId = 0;
            string personUsername = "Username";

            Person person = new Person(personId, personUsername);

            this.database.Add(person);

            Person dbPerson = this.database.FindById(personId);

            Assert.That(person, Is.EqualTo(dbPerson));
        }
    }
}