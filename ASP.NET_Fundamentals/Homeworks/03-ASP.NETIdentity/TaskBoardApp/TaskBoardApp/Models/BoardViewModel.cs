﻿using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Models
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
        }

        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
