using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;
using Task = TaskBoardApp.Data.Entities.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext dbContext;

        public TaskController(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = await this.GetBoardsAsync()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            var taskBoardsModels = await this.GetBoardsAsync();

            if (!taskBoardsModels.Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            string currentUserId = GetUserId();

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId,
            };

            await this.dbContext.Tasks.AddAsync(task);

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await this.dbContext.Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskDetailsViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                Board = t.Board.Name,
                Owner = t.Owner.UserName,
            })
            .FirstOrDefaultAsync();

            if (task is null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await this.dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await this.GetBoardsAsync(),
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await this.dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskBoardsModels = await this.GetBoardsAsync();

            if (!taskBoardsModels.Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist!");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await this.dbContext.Tasks.FindAsync(id);

            if (task is null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await this.dbContext.Tasks.FindAsync(taskModel.Id);

            if (task is null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            this.dbContext.Tasks.Remove(task);

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        private async Task<IEnumerable<TaskBoardModel>> GetBoardsAsync()
        {
            var taskBoardModels = await this.dbContext.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();

            return taskBoardModels;
        }

        private string GetUserId() => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
