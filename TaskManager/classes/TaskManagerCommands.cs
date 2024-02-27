using System.Net;
using System.Runtime.InteropServices;
using TaskManager.obj.enums;


namespace TaskManager.classes
{
    public class TaskManagerCommands
    {
        private readonly static TaskManager manager = new TaskManager();
        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Task Manager ;)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press to:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ADD : Add a new task");
            Console.WriteLine("EDIT : Edit a task");
            Console.WriteLine("DELETE : Delete a task");
            Console.WriteLine("LIST : List tasks");
            Console.WriteLine("HELP : List all commands");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("EXIT : Exit the file manager :(");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------");
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("adiós!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      made by @AbdellahBellakrim on GitHub         ");
            Environment.Exit(0);
        }

        public static void Add()
        {
            string? title = null;
            string? description = null;
            string? dateinput = null;
            string? status = null;
            DateTime dueDate = DateTime.Now;




            Console.WriteLine("Adding a new task please tap :");
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (string.IsNullOrEmpty(title))
                    {
                        Console.Write("Title : ");
                        title = Console.ReadLine()?.Trim();
                        if (string.IsNullOrEmpty(title))
                            throw new Exception("Title is required*");

                    }




                    if (string.IsNullOrEmpty(description))
                    {

                        Console.Write("Description : ");
                        description = Console.ReadLine()?.Trim();
                        if (string.IsNullOrEmpty(description))
                            throw new Exception("Description is required*");


                    }

                    if (string.IsNullOrEmpty(dateinput))
                    {
                        Console.Write("Enter the due date (MM/dd/yyyy): ");
                        dateinput = Console.ReadLine()?.Trim();
                        if (DateTime.TryParse(dateinput, out dueDate) == false)
                            throw new Exception("Invalid date format*");

                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        Console.Write("Status (complete, pending): ");
                        status = Console.ReadLine()?.Trim();
                        if (status != "complete" && status != "pending")
                            throw new Exception("Status must be complete or pending*");

                    }
                    Task newTask = manager.AddTask(title, description, dueDate.ToShortDateString(), (TaskState)Enum.Parse(typeof(TaskState), status));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nTask added successfully!");
                    newTask.DisplayTaskDetails();
                    break;

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Edit()
        {
            Console.WriteLine("To edit a task please tap the task Id (ps: copy it from list)");
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Id : ");
                    string? id = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(id))
                        throw new Exception("Id is required*");
                    Task? taskToEdit = manager.tasks.Find(t => t.Id == id);
                    if (taskToEdit == null)
                        throw new Exception("Task not found*");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter your new task details, if you want to keep the old value just press enter:");

                    string? title = taskToEdit.Title;
                    string? description = taskToEdit.Description;
                    string? dateinput = taskToEdit.DueDate;
                    string? status = taskToEdit.Status.ToString();
                    string? input = null;
                    DateTime dueDate = DateTime.Now;

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Title : ");
                    input = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(input))
                        title = input;





                    Console.Write("Description : ");
                    input = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(input))
                        description = input;



                    while (true)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Enter the due date (MM/dd/yyyy): ");
                            input = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrEmpty(input))
                            {
                                dateinput = input;
                                if (DateTime.TryParse(dateinput, out dueDate) == false)
                                    throw new Exception("Invalid date format*");
                            }
                            DateTime.TryParse(dateinput, out dueDate);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(e.Message);
                        }

                    }

                    while (true)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("Status (complete, pending): ");
                            input = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrEmpty(input))
                            {
                                if (input != "complete" && input != "pending")
                                    throw new Exception("Status must be complete or pending*");
                                status = input;
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(e.Message);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    taskToEdit.Title = title;
                    taskToEdit.Description = description;
                    taskToEdit.DueDate = dueDate.ToShortDateString();
                    taskToEdit.Status = (TaskState)Enum.Parse(typeof(TaskState), status);
                    taskToEdit.DisplayTaskDetails();
                    break;

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                }
            }

        }
        public static void Delete()
        {
            Console.WriteLine("To romove a task please tap the task Id (ps: copy it from list; this action is irreversible)");
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Id : ");
                    string? id = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(id))
                        throw new Exception("Id is required*");
                    Console.ForegroundColor = ConsoleColor.White;
                    Task? taskToRemove = manager.tasks.Find(t => t.Id == id);
                    if (taskToRemove != null)
                    {
                        manager.tasks.Remove(taskToRemove);
                        Console.WriteLine("Task removed successfully!");
                    }
                    else
                        throw new Exception("Task not found*");
                    break;

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}