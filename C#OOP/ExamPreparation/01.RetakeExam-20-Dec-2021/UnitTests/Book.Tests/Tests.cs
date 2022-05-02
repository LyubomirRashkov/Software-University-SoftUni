namespace Book.Tests
{

    using NUnit.Framework;

    public class Tests
    {
        private const string BookName = "Some Book";
        private const string Author = "Some Author";
        private const int FootnoteNumber = 1;
        private const string FootnoteText = "Some text";

        private Book book;

        [SetUp]
        public void Setup()
        {
            this.book = new Book(BookName, Author);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ThrowsException_WhenBookNameIsNullOrEmpty(string bookName)
        {
            Assert.That(() => new Book(bookName, Author), Throws.ArgumentException);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Consructor_ThrowsException_WhenAuthorIsNullOrEmpty(string author)
        {
            Assert.That(() => new Book(BookName, author), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(book.BookName, Is.EqualTo(BookName));
            Assert.That(book.Author, Is.EqualTo(Author));
            Assert.That(book.FootnoteCount, Is.Zero);
        }

        [Test]
        public void AddFootnote_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(book.FootnoteCount, Is.Zero);

            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }

        [Test]
        public void AddFootnote_ThrowsException_WhenThereIsAFootnoteWithTheGivenKey()
        {
            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(() => book.AddFootnote(FootnoteNumber, FootnoteText), Throws.InvalidOperationException);
        }

        [Test]
        public void FindFootnote_ThrowsException_WhenThereIsNotAFootnoteWithTheGivenKey()
        {
            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(() => book.FindFootnote(FootnoteNumber + 1), Throws.InvalidOperationException);
        }

        [Test]
        public void FindFootnote_ReturnsTheCorrectString_WhenDataIsValid()
        {
            book.AddFootnote(FootnoteNumber, FootnoteText);

            string expected = $"Footnote #{FootnoteNumber}: {FootnoteText}";

            string actual = book.FindFootnote(FootnoteNumber);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void AlterFootnote_ThrowsException_WhenThereIsNotAFootnoteWithTheGivenKey()
        {
            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(() => book.AlterFootnote(5, FootnoteText), Throws.InvalidOperationException);
        }

        [Test]
        public void AlterFootnote_WorksCorrectly_WhenDataIsValid()
        {
            book.AddFootnote(FootnoteNumber, FootnoteText);

            string newFootnoteText = "New text";

            book.AlterFootnote(FootnoteNumber, newFootnoteText);

            string expected = $"Footnote #{FootnoteNumber}: {newFootnoteText}";

            string actual = book.FindFootnote(FootnoteNumber);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}