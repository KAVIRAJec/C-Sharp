using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public delegate void ThresholdDeligate(string message);

    public class Counter
    {
        private int Count;
        private int Threshold;

        public event ThresholdDeligate ThresholdReached;

        public Counter(int threshold)
        {
            Count = 0;
            Threshold = threshold;
        }

        public void Increment()
        {
            Count++;
            Console.WriteLine($"Counter: {Count}");
            if (Count >= Threshold)
            {
                ThresholdReached?.Invoke($"Your counter is full with value {Count}");
            }
        }
    }
}
