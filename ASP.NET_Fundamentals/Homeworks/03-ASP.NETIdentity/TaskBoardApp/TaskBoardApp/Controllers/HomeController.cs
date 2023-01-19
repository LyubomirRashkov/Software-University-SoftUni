using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext dbContext;

        public HomeController(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boardsNames = await this.dbContext.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            var boardHomeModels = new List<BoardHomeModel>();

            foreach (var boardName in boardsNames)
            {
                var countOfTasksInCurrentBoard = await this.dbContext.Tasks
                    .Where(t => t.Board.Name == boardName)
                    .CountAsync();

                boardHomeModels.Add(new BoardHomeModel()
                {
                    BoardName = boardName,
                    TasksCount = countOfTasksInCurrentBoard,
                });
            }

            int userTasksCount = 0;

            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                var currentUserId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                userTasksCount = await this.dbContext.Tasks
                    .Where(t => t.OwnerId == currentUserId)
                    .CountAsync();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = await this.dbContext.Tasks.CountAsync(),
                BoardsWithTasksCount = boardHomeModels,
                UserTasksCount = userTasksCount,
            };

            return View(homeModel);
        }
    }
}