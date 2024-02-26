using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager
{
    public class ConsoleUI
    {
        public void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Task Manager!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press to:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ADD - Add a new task");
            Console.WriteLine("EDIT - Edit a task");
            Console.WriteLine("DELETE - Delete a task");
            Console.WriteLine("LIST - List all tasks");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("EXIT - Exit the file manager");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=====================================================");
            while (true)
            {
                Console.Write("Enter a command: ");
                string command = Console.ReadLine();
                Console.WriteLine(command);
            }
        }
    }
}