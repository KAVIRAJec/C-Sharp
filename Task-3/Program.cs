using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class Task
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Task(string name, string description)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Task Name or Description cannot be empty");
            }
            Name = name;
            Description = description;
        }

        public void updateTask (string name, string description)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Task Name or Description cannot be empty");
            }
            Name = name;
            Description = description;
        }
    }
    internal class Program
    {
        static private List<Task> Tasks = new List<Task>();
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter any of the following options");
                    Console.WriteLine("1. Create Task");
                    Console.WriteLine("2. Display Task");
                    Console.WriteLine("3. Update Task");
                    Console.WriteLine("4. Delete Task");
                    Console.WriteLine("5. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            CreateTask();
                            break;
                        case 2:
                            DisplayTask();
                            break;
                        case 3:
                            Console.Write("Enter Task ID to Update: ");
                            UpdateTask(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 4:
                            Console.Write("Enter Task ID to Delete: ");
                            DeleteTask(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                    Console.WriteLine();
                }
            } catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        static void CreateTask()
        {
            Console.Write("Enter Task Name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Enter Task Description: ");
            string description = Console.ReadLine().Trim();
            Tasks.Add(new Task(name, description));
        }

        static void DisplayTask()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No Tasks Found");
            } else
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    Console.WriteLine($"Task {i + 1}: {Tasks[i].Name} - {Tasks[i].Description}");
                }
            }
        }

        static void UpdateTask(int id)
        {
            if (id < 0 || id > Tasks.Count)
            {
                Console.WriteLine("Invalid Task");
                return;
            }

            Task task = Tasks[id - 1];
            Console.Write("Enter New Task Name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Enter New Task Description: ");
            string description = Console.ReadLine().Trim();

            try
            {
                task.updateTask(name, description);
                Console.WriteLine("Task Updated");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void DeleteTask(int id)
        {
            if (id < 0 || id > Tasks.Count)
            {
                Console.WriteLine("Invalid Task");
                return;
            }

            try
            {
                Tasks.RemoveAt(id);
                Console.WriteLine("Task Updated");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
