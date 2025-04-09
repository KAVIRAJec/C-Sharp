using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public static class  CustomFilter
    {
        static public List<Student> FilterStudentByGrade(List<Student> Students ,double grade)
        {
            return Students.Where(student => student.Grade >= grade).ToList();
        }
        static public List<Student> SortStudentByName(List<Student> Students)
        {
            return Students.OrderBy(student => student.Name).ToList();
        }
        static public List<Student> SortStudentByGrade(List<Student> Students)
        {
            return Students.OrderByDescending(student => student.Grade).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Student> Students = new List<Student>
                {
                new Student("John Doe", 85.5, 20),
                new Student("Jane Smith", 92.3, 22),
                new Student("Alice Johnson", 76.8, 19),
                new Student("Bob Brown", 59.4, 23),
                new Student("Charlie Davis", 88.9, 21)
                };

                // Display all students
                Console.WriteLine("All Students:");
                DisplayStudents(Students);
                Console.WriteLine();

                // Filter student by Mark
                Console.Write("Enter the grade to filter the students:");
                double grade = Convert.ToDouble(Console.ReadLine());
                List<Student> filterStudent = CustomFilter.FilterStudentByGrade(Students, grade);
                if (filterStudent.Any())
                {
                    Console.WriteLine($"The students Filtered by grade with {grade}:");
                    DisplayStudents(filterStudent);
                }
                else
                {
                    Console.WriteLine($"No student found with grade {grade}");
                }
                Console.WriteLine();

                // Sort students by name
                List<Student> SortedStudent = CustomFilter.SortStudentByName(Students);
                Console.WriteLine("Student sorted By Name:");
                DisplayStudents(SortedStudent);
                Console.WriteLine();

                // Sort students by Grade
                List<Student> SortedStudent1 = CustomFilter.SortStudentByGrade(Students);
                Console.WriteLine("Student sorted By Grade(Desc):");
                DisplayStudents(SortedStudent1);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        static void DisplayStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
            }
        }
    }
}
