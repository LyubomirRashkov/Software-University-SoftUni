using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await this.bookService.GetAllBooksAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookImportViewModel()
            {
                Categories = await this.bookService.GetAllCategoriesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookImportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.bookService.AddBookAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong... Try again!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = this.GetUserId();

                await this.bookService.AddBookToUserCollectionAsync(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = this.GetUserId();

            var userBooks = await this.bookService.GetUserBooksAsync(userId);

            return View(userBooks);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            string userId = this.GetUserId();

            await this.bookService.RemoveBookFromUserCollectionAsync(bookId, userId);

            return RedirectToAction(nameof(Mine));
        }

        private string GetUserId() => this.User.Claims
                                         .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
    }
}
