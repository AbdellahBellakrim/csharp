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
                TaskManagerCommands.Edit();

            else if (command == "DELETE")
                Console.WriteLine("Deleting a task");
            else if (command == "HELP")
                TaskManagerCommands.Help();
            else if (command == "EXIT")
                TaskManagerCommands.Exit();
            else if (command == "LIST")
                Console.WriteLine("Listing ...");
            else
                Console.WriteLine("unknown command");
        }
    }
}