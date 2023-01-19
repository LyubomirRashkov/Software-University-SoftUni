using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext dbContext;

        public BoardController(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var boards = await this.dbContext.Boards
            .Select(b => new BoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks
                         .Select(t => new TaskViewModel()
                         {
                             Id = t.Id,
                             Title = t.Title,
                             Description = t.Description,
                             Owner = t.Owner.UserName,
                         }),
            })
            .ToListAsync();

            return View(boards);
        }
    }
}
