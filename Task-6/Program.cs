using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(10);
            counter.ThresholdReached += Counter_ThresholdReached1;
            counter.ThresholdReached += Counter_ThresholdReached2;

            Console.WriteLine("Press Enter to increase the counter, Type Exit to quit");

            while (true)
            {
                string value = Console.ReadLine();
                if (value.ToLower() == "exit") break;
                counter.Increment();
            }
        }
        private static void Counter_ThresholdReached1(string message)
        {
            Console.WriteLine($"We got an alert: {message}");
        }
        private static void Counter_ThresholdReached2(string message)
        {
            Console.WriteLine($"Request Timeout: {message}");
        }
    }
}
