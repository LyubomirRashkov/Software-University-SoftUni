using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookExportToAllViewModel>> GetAllBooksAsync();

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        Task AddBookAsync(BookImportViewModel model);

        Task AddBookToUserCollectionAsync(int bookId, string userId);

        Task<IEnumerable<BookExportToUsersViewModel>> GetUserBooksAsync(string userId);

        Task RemoveBookFromUserCollectionAsync(int bookId, string userId);
    }
}
