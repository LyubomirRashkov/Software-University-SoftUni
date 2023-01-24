using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(BookImportViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
            };

            await this.dbContext.Books.AddAsync(book);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddBookToUserCollectionAsync(int bookId, string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            var book = await this.dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book is null)
            {
                throw new ArgumentException("Invalid book id!");
            }

            if (!user.ApplicationUsersBooks.Any(aub => aub.BookId == bookId))
            {
                var applicationUserBook = new ApplicationUserBook()
                {
                    ApplicationUserId = userId,
                    BookId = bookId,
                };

                user.ApplicationUsersBooks.Add(applicationUserBook);

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookExportToAllViewModel>> GetAllBooksAsync()
        {
            var books = await this.dbContext.Books
               .Select(b => new BookExportToAllViewModel()
               {
                   Id = b.Id,
                   ImageUrl = b.ImageUrl,
                   Title = b.Title,
                   Author = b.Author,
                   Rating = b.Rating,
                   Category = b.Category.Name,
               })
               .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await this.dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<BookExportToUsersViewModel>> GetUserBooksAsync(string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user id!");
            }

            var userBooks = user.ApplicationUsersBooks
                .Select(aub => new BookExportToUsersViewModel()
                {
                    Id = aub.BookId,
                    ImageUrl = aub.Book.ImageUrl,
                    Title = aub.Book.Title,
                    Author = aub.Book.Author,
                    Description = aub.Book.Description,
                    Category = aub.Book.Category.Name,
                })
                .ToList();

            return userBooks;
        }

        public async Task RemoveBookFromUserCollectionAsync(int bookId, string userId)
        {
            var user = await this.GetUserAsync(userId);

            if (user is null)
            {
                throw new ArgumentException("Invalid user id!");
            }

            var userBook = user.ApplicationUsersBooks.FirstOrDefault(aub => aub.BookId == bookId);

            if (userBook is null)
            {
                throw new ArgumentException("Invalid book id!");
            }

            user.ApplicationUsersBooks.Remove(userBook);

            await this.dbContext.SaveChangesAsync();
        }

        private async Task<ApplicationUser> GetUserAsync(string userId)
        {
            var user = await this.dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(aub => aub.Book)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
