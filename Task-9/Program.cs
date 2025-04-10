using System;
using System.Linq;
using System.Reflection;

namespace Task_9
{
    public class Program
    {
        public static void RunCustomerAttribute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes(); // Class

            foreach(var type in types)
            {
                var methods = type.GetMethods().Where(m => m.GetCustomAttribute<RunnableAttribute>() != null).ToList(); // get Runnable Custom Attribute

                if(methods.Any())
                {
                    var instance = Activator.CreateInstance(type); // create Object

                    foreach(var method in methods)
                    {
                        Console.WriteLine($"Running {type.Name}.{method.Name}():");
                        method.Invoke(instance, null);
                        Console.WriteLine();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            RunCustomerAttribute();
        }
    }
}
