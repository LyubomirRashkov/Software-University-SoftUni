using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;

            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[currentIndex];

            public bool MoveNext()
            {
                this.currentIndex++;

                if (this.currentIndex < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }
        }
    }
}
