using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        private static long CalculateFactorial(int number)
        {
            long factorial = 1;
            while (number > 0)
            {
                factorial *= number--;
            }
            return factorial;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the Number: ");
            var number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("Please input positive number");
            }
            else
            {
                long factorial = CalculateFactorial(number);
                Console.WriteLine("Factorial of {0} is {1}", number, factorial);
            }
        }
}
}