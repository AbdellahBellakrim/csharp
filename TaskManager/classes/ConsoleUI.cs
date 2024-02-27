using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManager.classes;

namespace TaskManager
{
    public class ConsoleUI
    {
        public void Start()
        {
            TaskManagerCommands.Help();
            while (true)
            {
                Console.Write("> : ");
                string? command = Console.ReadLine();
                if (string.IsNullOrEmpty(command) == false)
                    Parse(command);
                else
                    Console.WriteLine("unknown command");

            }
        }

        public void Parse(string command)
        {
            command = command.Trim();
            if (command == "ADD")
                TaskManagerCommands.Add();
            else if (command == "EDIT")
                Console.WriteLine("Editing a task");
            else if (command == "DELETE")
                Console.WriteLine("Deleting a task");
            else if (command == "HELP")
                TaskManagerCommands.Help();
            else if (command == "EXIT")
                TaskManagerCommands.Exit();
            else
            {
                string cleanedcommand = Regex.Replace(command, @"\s+", " ");
                if (cleanedcommand == "LIST --C")
                    Console.WriteLine("Listing all complete tasks");
                else if (cleanedcommand == "LIST --P")
                    Console.WriteLine("Listing all pending tasks");
                else if (cleanedcommand == "LIST --A")
                    Console.WriteLine("Listing all tasks");
                else
                    Console.WriteLine("unknown command");
            }
        }
    }
}