using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public class Student
    {
        public string Name { get; private set; }
        public double Grade { get; private set; }
        public int Age { get; private set; }

        public Student(string Name, double Grade, int Age)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Name cannot be empty");
                if (Grade < 0 || Grade > 100) throw new ArgumentOutOfRangeException("Grade must be between 0 and 100");
                if (Age < 0 && Age > 50) throw new ArgumentOutOfRangeException("Age is invalid");
                this.Name = Name;
                this.Grade = Grade;
                this.Age = Age;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
