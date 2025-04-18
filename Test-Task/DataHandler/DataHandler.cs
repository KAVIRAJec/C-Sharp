using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Test_Task
{
    public static class DataHandler
    {
        public static async Task SaveAndLoadData(LibraryManager libraryManager, MemberManager memberManager)
        {
            Console.Clear();
            Console.WriteLine("---- SAVE AND LOAD DATA ----");
            Console.WriteLine("1. Save Data");
            Console.WriteLine("2. Load Data");
            Console.WriteLine("3. Save and Backup data");
            Console.WriteLine("4. Back to Main Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await DataHandler.SaveDataAsync(libraryManager.LibraryItems, memberManager.LibraryMembers);
                    break;
                case "2":
                    var (loadedItems, loadedMembers) = await DataHandler.LoadDataAsync();
                    libraryManager.LibraryItems = loadedItems;
                    memberManager.LibraryMembers = loadedMembers;
                    break;
                case "3":
                    await DataHandler.SaveDataAsync(libraryManager.LibraryItems, memberManager.LibraryMembers);
                    await DataHandler.BackupDataAsync();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new LibraryItemJsonConverter() }
            };
        }

        private const string LibraryFile = "C:\\Users\\91986\\Downloads\\Presidio-C#\\Presidio-Tasks\\Test-Task\\Files\\items.json";
        private const string MembersFile = "C:\\Users\\91986\\Downloads\\Presidio-C#\\Presidio-Tasks\\Test-Task\\Files\\members.json";

        public static async Task SaveDataAsync(List<LibraryItem> libraryItems, List<LibraryMember> libraryMembers)
        {
            try
            {
                var options = GetJsonSerializerOptions();
                await Task.Run(() => File.WriteAllText(LibraryFile, JsonSerializer.Serialize(libraryItems, options)));
                await Task.Run(() => File.WriteAllText(MembersFile, JsonSerializer.Serialize(libraryMembers, options)));
                Console.WriteLine("Data saved successfully.");
            } catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }          
        }
        public static async Task<(List<LibraryItem>, List<LibraryMember>)> LoadDataAsync()
        {
            List<LibraryItem> libraryItems = new List<LibraryItem>();
            List<LibraryMember> libraryMembers = new List<LibraryMember>();
        
            try
            {
                var options = GetJsonSerializerOptions();
                if (File.Exists(LibraryFile))
                {
                    string itemJson = await Task.Run(() => File.ReadAllText(LibraryFile));
                    libraryItems = JsonSerializer.Deserialize<List<LibraryItem>>(itemJson, options);
                }
                if (File.Exists(MembersFile))
                {
                    string memberJson = await Task.Run(() => File.ReadAllText(MembersFile));
                    libraryMembers = JsonSerializer.Deserialize<List<LibraryMember>>(memberJson, options);
                }
                Console.WriteLine("Data loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
            return (libraryItems, libraryMembers);
        }
        public static async Task BackupDataAsync()
        {
            try
            {
                string backupLibraryFile = LibraryFile + ".bak";
                string backupMembersFile = MembersFile + ".bak";

                if (File.Exists(LibraryFile))
                {
                    await Task.Run(() => File.Copy(LibraryFile, backupLibraryFile, true));
                }
                if (File.Exists(MembersFile))
                {
                    await Task.Run(() => File.Copy(MembersFile, backupMembersFile, true));
                }
                Console.WriteLine("Backup completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during backup: {ex.Message}");
            }
        }
    }
}
