using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    public class Async
    {
        public async Task<List<string>> FetchTask()
        {
            List<Task<string>> results = new List<Task<string>> { Task1(), Task2(), Task3() };
            List<string> response = new List<string>();
            try
            {
                while(results.Count > 0)
                {
                    Task<string> task = await Task.WhenAny(results);
                    response.Add(await task);
                    results.Remove(task);
                    //Console.WriteLine(task.Result);
                }
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<string>();
            }
        }
        public async Task<string> Task1()
        {
            await Task.Delay(3000);
            return "Async Task 1 completed";
        }
        public async Task<string> Task2()
        {
            await Task.Delay(1000);
            return "Async Task 2 completed";
        }
        public async Task<string> Task3()
        {
            await Task.Delay(2000);
            return "Async Task 3 completed";
        }
    }
}
