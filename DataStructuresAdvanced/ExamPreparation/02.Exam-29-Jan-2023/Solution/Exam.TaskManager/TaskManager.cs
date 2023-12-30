using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private readonly Dictionary<string, Task> tasksById;
        private readonly List<Task> pendingTasks;
        private readonly List<Task> completedTasks;

        public TaskManager()
        {
            this.tasksById = new Dictionary<string, Task>();
            this.pendingTasks = new List<Task>();
            this.completedTasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (!this.tasksById.ContainsKey(task.Id))
            {
                this.tasksById.Add(task.Id, task);

                this.pendingTasks.Add(task);
            }
        }

        public bool Contains(Task task) => this.tasksById.ContainsKey(task.Id);

        public int Size() => this.pendingTasks.Count;

        public Task GetTask(string taskId)
        {
            this.ValidateTaskExists(taskId);

            return this.tasksById[taskId];
        }

		public void DeleteTask(string taskId)
        {
            this.ValidateTaskExists(taskId);

            Task task = this.tasksById[taskId];

            this.tasksById.Remove(taskId);

            this.pendingTasks.Remove(task); 
            
            this.completedTasks.Remove(task);
        }

        public Task ExecuteTask()
        {
            Task task = this.pendingTasks.FirstOrDefault();

            if (task is null)
            {
                throw new ArgumentException();
            }

            this.pendingTasks.RemoveAt(0);

            this.completedTasks.Add(task);
            
            return task;
        }

        public void RescheduleTask(string taskId)
        {
            Task task = this.completedTasks.FirstOrDefault(t => t.Id == taskId);

            if (task is null)
            {
                throw new ArgumentException();
            }

            this.completedTasks.Remove(task);

            this.pendingTasks.Add(task);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var filteredTasks = this.pendingTasks
                .Where(t => t.Domain == domain);

            if (filteredTasks.Count() == 0)
            {
                throw new ArgumentException();
            }

            return filteredTasks;
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
            => this.pendingTasks
               .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
            => this.tasksById.Values
               .OrderByDescending(t => t.EstimatedExecutionTime)
               .ThenBy(t => t.Name.Length);

		private void ValidateTaskExists(string taskId)
		{
            if (!this.tasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
		}
    }
}
