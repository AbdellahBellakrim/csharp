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
            Console.WriteLine("Welcome to Task Manager!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press to:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ADD : Add a new task");
            Console.WriteLine("EDIT : Edit a task");
            Console.WriteLine("DELETE : Delete a task");
            Console.WriteLine("LIST --C : List all complete tasks");
            Console.WriteLine("LIST --P : List all pending tasks");
            Console.WriteLine("LIST --A : List all tasks");
            Console.WriteLine("HELP : List all commands");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("EXIT : Exit the file manager");
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
            Console.WriteLine("         made by @AbdellahBellakrim on GitHub      ");
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
                        title = Console.ReadLine();
                        if (string.IsNullOrEmpty(title))
                            throw new Exception("Title is required*");

                    }




                    if (string.IsNullOrEmpty(description))
                    {

                        Console.Write("Description : ");
                        description = Console.ReadLine();
                        if (string.IsNullOrEmpty(description))
                            throw new Exception("Description is required*");


                    }

                    if (string.IsNullOrEmpty(dateinput))
                    {
                        Console.Write("Enter the due date (MM/dd/yyyy): ");
                        dateinput = Console.ReadLine();
                        if (DateTime.TryParse(dateinput, out dueDate) == false)
                            throw new Exception("Invalid date format*");

                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        Console.Write("Status (complete, pending): ");
                        status = Console.ReadLine();
                        if (status != "complete" && status != "pending")
                            throw new Exception("Status must be complete or pending*");

                    }
                    manager.AddTask(title, description, dueDate.ToShortDateString(), (TaskState)Enum.Parse(typeof(TaskState), status));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Task {title} added successfully!");
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