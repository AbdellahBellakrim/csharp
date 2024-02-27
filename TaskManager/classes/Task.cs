using TaskManager.obj.enums;

namespace TaskManager
{
    public class Task
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public TaskState Status { get; set; }

        public Task(string title, string description, string dueDate, TaskState status)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }

        public void DisplayTaskDetails()
        {
            Console.WriteLine($"Task ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Due Date: {DueDate}");
            Console.WriteLine($"Status: {Status}");
        }
    }
}