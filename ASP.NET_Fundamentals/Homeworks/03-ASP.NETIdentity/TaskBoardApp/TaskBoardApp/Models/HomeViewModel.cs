namespace TaskBoardApp.Models
{
	public class HomeViewModel
	{
		public HomeViewModel()
		{
			this.BoardsWithTasksCount = new List<BoardHomeModel>();
		}

		public int AllTasksCount { get; init; }

		public ICollection<BoardHomeModel> BoardsWithTasksCount { get; init; }

		public int UserTasksCount { get; init; }
	}
}
