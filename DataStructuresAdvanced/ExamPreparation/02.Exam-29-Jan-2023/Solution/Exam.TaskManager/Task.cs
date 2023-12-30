namespace Exam.TaskManager
{
    public class Task
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int EstimatedExecutionTime { get; set; }

        public string Domain { get; set; }

        public Task(string id, string name, int estimatedExecutionTime, string domain)
        {
            this.Id = id;
            this.Name = name;
            this.EstimatedExecutionTime = estimatedExecutionTime;
            this.Domain = domain;
        }
    }
}
