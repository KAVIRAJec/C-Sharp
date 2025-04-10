using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_5
{
    public static class FileOperation
    {
        public static bool ValidateFile(string fileName, string filePath)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(filePath)) throw new ArgumentException("File name or path cannot be null or empty.");
            //if (!fileName.EndsWith(".csv"))throw new ArgumentException("File extension must be .csv");
            if (Directory.Exists(filePath))
            {
                if (File.Exists(filePath + '/' + fileName)) return true;
                else throw new FileNotFoundException($"File not found: {filePath + fileName}");
            }
            else throw new DirectoryNotFoundException($"Directory not found: {filePath}");
        }

        public static bool CreateFile(string fileName, string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath)) throw new Exception($"Directory not found: {filePath}");
                if (File.Exists(filePath + '/' + fileName)) throw new IOException($"File already exists: {filePath + fileName}");
                File.Create(filePath + '/' + fileName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static void ReadFile(string fileName, string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath + '/' + fileName);
                Console.WriteLine(content);
                Console.WriteLine($"Number of Lines: {File.ReadAllLines(filePath + '/' + fileName).Length}");
                Console.WriteLine($"Number of Words: {content.Split(' ').Length}");
                Console.WriteLine("Read Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteFile(string fileName, string filePath)
        {
            try
            {
                Console.Write("Enter 1 to replace all, 2 to insert at end: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if(option == 1)
                {
                    Console.WriteLine("Enter new content:");
                    string content = Console.ReadLine();
                    File.WriteAllText(filePath + '/' + fileName, content);
                } else if ( option == 2)
                {
                    Console.WriteLine("Enter content:");
                    string content = Console.ReadLine();
                    File.AppendAllText(filePath + '/' + fileName, content);
                }
                Console.WriteLine("Write Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeleteFile(string fileName, string filePath)
        {
            try
            {
                File.Delete(filePath + '/' + fileName);
                Console.WriteLine("Delete Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the below options:");
                Console.WriteLine("1. Create a file");
                Console.WriteLine("2. Read a file");
                Console.WriteLine("3. Write to a file");
                Console.WriteLine("4. Delete a file");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your option: ");
                var option = int.TryParse(Console.ReadLine(), out int value) ? value : 0;

                switch (option)
                {
                    case 1:
                        CreateFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        WriteFile();
                        break;
                    case 4:
                        DeleteFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void CreateFile()
        {
            try
            {
                Console.Write("Enter file Path to create: ");
                var filePath = Console.ReadLine();
                Console.Write("Enter file name: ");
                var fileName = Console.ReadLine();
                if (FileOperation.CreateFile(fileName, filePath))
                {
                    Console.WriteLine($"File created successfully: {filePath + fileName}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadFile()
        {
            try
            {
                Console.Write("Enter file Path: ");
                var filePath = Console.ReadLine();
                Console.Write("Enter file name: ");
                var fileName = Console.ReadLine();
                if(FileOperation.ValidateFile(fileName, filePath))
                {
                    Console.WriteLine("File Retrived.");
                    Console.WriteLine();
                    FileOperation.ReadFile(fileName, filePath);
                }

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void WriteFile()
        {
            try
            {
                Console.Write("Enter file Path: ");
                var filePath = Console.ReadLine();
                Console.Write("Enter file name: ");
                var fileName = Console.ReadLine();
                if (FileOperation.ValidateFile(fileName, filePath))
                {
                    Console.WriteLine("File Retrived");
                    FileOperation.WriteFile(fileName, filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void DeleteFile()
        {
            try
            {
                Console.Write("Enter file Path: ");
                var filePath = Console.ReadLine();
                Console.Write("Enter file name: ");
                var fileName = Console.ReadLine();
                if (FileOperation.ValidateFile(fileName, filePath))
                {
                    FileOperation.DeleteFile(fileName, filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
