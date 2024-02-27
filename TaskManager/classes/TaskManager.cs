using TaskManager.obj.enums;

namespace TaskManager
{
    public class TaskManager
    {
        public List<Task> tasks = new List<Task>();
        public Task AddTask(string title, string description, string dueDate, TaskState status)
        {
            Task task = new Task(title, description, dueDate, status);
            tasks.Add(task);
            return task;
        }

        public void EditTask(string id, string title, string description, string dueDate, TaskState status)
        {
            try
            {
                Task? task = tasks.Find(t => t.Id == id);
                if (task != null)
                {
                    task.Title = title;
                    task.Description = description;
                    task.DueDate = dueDate;
                    task.Status = status;
                }
                else
                    throw new Exception("Task not found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ViewAllTasks()
        {
            foreach (var task in tasks)
            {
                task.DisplayTaskDetails();
                Console.WriteLine("===================================================");
            }
        }
    }
}