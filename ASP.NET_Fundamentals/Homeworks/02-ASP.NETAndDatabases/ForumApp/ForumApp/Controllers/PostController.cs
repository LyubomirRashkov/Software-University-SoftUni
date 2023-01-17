using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumDbContext context;

        public PostController(ForumDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<PostViewModelEdit> model = await this.context.Posts
                .Where(p => p.IsDeleted == false)
                .Select(p => new PostViewModelEdit()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostViewModelAdd();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModelEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.context.Posts.Add(new Post()
            {
                Title = model.Title,
                Content = model.Content,
            });

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await this.context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostViewModelEdit()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .FirstOrDefaultAsync();

            if (post != null)
            {
                return View(post);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModelEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await this.context.Posts.FindAsync(model.Id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await this.context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDeleted = true;

                await this.context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}