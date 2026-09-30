using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                switch ((Menu)menuSelected)
                {
                    case Menu.Add:
                        ShowMenuAdd();
                        break;

                    case Menu.Remove:
                        ShowMenuRemove();
                        break;

                    case Menu.List:
                        ShowMenuTaskList();
                        break;
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuSelected = Console.ReadLine();

            if (int.TryParse(menuSelected, out int option))
            {
                return option;
            }

            return 0;
        }
        
        public static void DisplayTasks()
        {
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TaskList[i]}");
            }

            Console.WriteLine("----------------------------------------");
        }

        public static void ShowMenuRemove()
        {
            // Check if there are tasks to remove
            // If not, show message and return
            // KISS recomienda salir temprano.
            
            if (TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas para eliminar");
                return;
            }

            // If there are tasks, show the list and ask for the number of the task to remove
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            // Show current taks
            DisplayTasks();

            // If the number is invalid, show a message and return
            if (!int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                Console.WriteLine("Ingrese un número válido");
                return;
            }

            int indexToRemove = taskNumber - 1;

            if (indexToRemove < 0 || indexToRemove >= TaskList.Count)
            {
                Console.WriteLine("Número de tarea inválido");
                return;
            }

            // If the number is valid, remove the task and show a message
            string taskToRemove = TaskList[indexToRemove];

            TaskList.RemoveAt(indexToRemove);

            Console.WriteLine($"Tarea '{taskToRemove}' eliminada");
        }
        
        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                TaskList.Add(newTask);
                Console.WriteLine($"Tarea '{newTask}' registrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                DisplayTasks();
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
