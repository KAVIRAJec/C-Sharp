using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Initialization of Thread Methods");
            try
            {
                MultiThread multithread = new MultiThread();
                List<string> results = multithread.ImplementThread();

                foreach (string result in results)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("End of Thread Methods");
            }

            Console.WriteLine("Initialization of Asynchronous Methods");
            try
            {
                Async async = new Async();
                List<string> result = await async.FetchTask();
                foreach(string item in result)
                {
                    Console.WriteLine(item);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("End of Asynchronous Methods");
            }
        }
    }
}
