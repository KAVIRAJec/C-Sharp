using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IRepository<Student> StudentRepo = new InMemoryRepository<Student>();

                while (true)
                {
                    Console.WriteLine("\tStudent Repository");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View Student");
                    Console.WriteLine("3. View All Students");
                    Console.WriteLine("4. Update Student");
                    Console.WriteLine("5. Delete Student");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Name:");
                            string name = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            StudentRepo.Add(new Student { Name = name, Age = age });
                            Console.WriteLine("Student added!");
                            break;

                        case "2":
                            Console.Write("Enter student ID: ");
                            int viewId = Convert.ToInt32(Console.ReadLine());
                            Student student = StudentRepo.Get(viewId);
                            Console.WriteLine(student != null ? student.ToString() : "Student not found.");
                            break;

                        case "3":
                            var allStudent = StudentRepo.GetAll();
                            foreach (Student st in allStudent)
                                Console.WriteLine(st);
                            break;

                        case "4":
                            Console.Write("Enter student ID to update: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Name:");
                            string newName = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            int newAge = Convert.ToInt32(Console.ReadLine());

                            StudentRepo.Update(updateId, new Student { Name = newName, Age = newAge });
                            Console.WriteLine("Student updated.");
                            break;

                        case "5":
                            Console.Write("Enter Student ID to Delete: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            StudentRepo.Delete(deleteId);
                            Console.WriteLine("Student deleted.");
                            break;

                        case "6":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
