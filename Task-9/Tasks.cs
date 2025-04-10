using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    public class Task1
    {
        [Runnable]
        public void ExecuteTask1()
        {
            Console.WriteLine("This is the Task1");
        }
    }
    public class Task2
    {
        [Runnable]
        public void ExecuteTask2()
        {
            Console.WriteLine("This is the Task2");
        }
    }
    public class Task3
    {
        [Runnable]
        public void ExecuteTask3()
        {
            Console.WriteLine("This is the Task3");
        }
        public void PerformTask3()
        {
            Console.WriteLine("This is from Task3 but not Runnable Custom Attribute");
        }
    }
}
