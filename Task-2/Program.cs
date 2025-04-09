using System;
using System.Text;

namespace Task_2
{
    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name="UserName", int age = 18)
        {
            Name = name;
            Age = age;
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person1 = new Person("Prabhu", 25);
                Person person2 = new Person("Dragavan", 21);
                Person person3 = new Person();

                person1.Introduce();
                person2.Introduce();
                person3.Introduce();

            } catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
