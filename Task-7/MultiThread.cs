using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_7
{
    public class MultiThread
    {
        public List<string> ImplementThread()
        {
            List<Task<string>> threadTask = new List<Task<string>>
            {
                Task.Run(() => Task1()),
                Task.Run(() => Task2()),
                Task.Run(() => Task3())
            };

            List<string> threadResults = new List<string>();

            while(threadTask.Count > 0)
            {
                Task<string> response = Task.WhenAny(threadTask).Result;
                string result = response.Result;
                threadResults.Add(result);
                threadTask.Remove(response);
                //Console.WriteLine(result);
            }
            return threadResults;
        }
        public string Task1()
        {
            //Thread.Sleep(3000);
            return $"Thread Task 1 completed {Thread.CurrentThread.ManagedThreadId}";
        }
        public string Task2()
        {
            //Thread.Sleep(1000);
            return $"Thread Task 2 completed {Thread.CurrentThread.ManagedThreadId}";
        }
        public string Task3()
        {
            //Thread.Sleep(2000);
            return $"Thread Task 3 completed {Thread.CurrentThread.ManagedThreadId}";
        }
    }

}
