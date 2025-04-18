using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    public static class ManageLibraryItem
    {
        public static void AddLibraryItem(LibraryManager libraryManager)
        {
            while (true)
            {
                Console.Write("Enter item title: ");
                string title = Console.ReadLine();
                Console.Write("Enter item author: ");
                string author = Console.ReadLine();
                Console.Write("Enter publication year: ");
                int publicationYear = int.TryParse(Console.ReadLine(), out int year) ? year : 0;
                //Console.Write("Enter stock count: ");
                //int stockCount = int.TryParse(Console.ReadLine(), out int count) ? count : 0;

                Console.Write("Enter item type (Book, Magazine, DigitalResource): ");
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Book":
                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();
                        Console.Write("Enter Page Count: ");
                        int pageCount = int.TryParse(Console.ReadLine(), out int pages) ? pages : 0;
                        libraryManager.AddItem(new Book { Title = title, Author = author, PublicationYear = publicationYear, Genre = genre, PageCount = pageCount });
                        return;
                    case "Magazine":
                        Console.Write("Enter Issue Number: ");
                        int issueNumber = int.TryParse(Console.ReadLine(), out int issue) ? issue : 0;
                        Console.Write("Enter Publisher: ");
                        string publisher = Console.ReadLine();
                        libraryManager.AddItem(new Magazine { Title = title, Author = author, PublicationYear = publicationYear, IssueNumber = issueNumber, Publisher = publisher });
                        return;
                    case "DigitalResource":
                        Console.WriteLine("Enter the format: ");
                        string format = Console.ReadLine();
                        Console.WriteLine("Enter the file size: ");
                        double fileSize = double.TryParse(Console.ReadLine(), out double size) ? size : 0;
                        libraryManager.AddItem(new DigitalResource { Title = title, Author = author, PublicationYear = publicationYear, Format = format, FileSize = fileSize });
                        return;
                    default:
                        Console.WriteLine("Invalid item type. Please try again.");
                        continue;
                }
            }
        }
        public static void FilterLibraryItemsByStatus(LibraryManager libraryManager)
        {
            Console.Write("Enter status to filter (Available, CheckedOut, OnHold): ");
            if (Enum.TryParse(Console.ReadLine(), out LibraryItem.Status status))
            {
                libraryManager.FilterByStatus(status);
            }
            else
            {
                Console.WriteLine("Invalid status. Please try again.");
            }
        }

        public static void FilterLibraryItemsByType(LibraryManager libraryManager)
        {
            Console.Write("Enter type to filter (Book, Magazine, DigitalResource): ");
            string type = Console.ReadLine();
            if (type.Equals("Book", StringComparison.OrdinalIgnoreCase))
            {
                libraryManager.FilterByType<Book>();
            }
            else if (type.Equals("Magazine", StringComparison.OrdinalIgnoreCase))
            {
                libraryManager.FilterByType<Magazine>();
            }
            else if (type.Equals("DigitalResource", StringComparison.OrdinalIgnoreCase))
            {
                libraryManager.FilterByType<DigitalResource>();
            }
            else
            {
                Console.WriteLine("Invalid type. Please try again.");
            }
        }
        public static void DeleteLibraryItem(LibraryManager libraryManager)
        {
            Console.Write("Enter the ID of the item to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = libraryManager.LibraryItems.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    libraryManager.DeleteItem(item);
                }
                else
                {
                    Console.WriteLine("Item not found. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please try again.");
            }
        }

        public static void SearchLibraryCatalog(MemberManager memberManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- SEARCH LIBRARY CATALOG ----");
                Console.WriteLine("1. Search member Catalog");
                Console.WriteLine("2. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Member ID to view History: ");
                        try
                        {
                            int memberId = int.TryParse(Console.ReadLine(), out int id) ? id : 0;
                            if (memberId > 0)
                            {
                                var member = memberManager.LibraryMembers.FirstOrDefault(m => m.MemberId == memberId);
                                if (member != null)
                                {
                                    if(member.memberActivities.Count>0)Console.WriteLine($"Member History for {member.Name}:");
                                    else Console.WriteLine($"No history found for {member.Name}.");
                                    foreach (var activity in member.memberActivities)
                                        {
                                            Console.WriteLine(activity.ToString());
                                        }
                                }
                                else Console.WriteLine("Member not found.");
                            }
                            else Console.WriteLine("Invalid Member ID.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: ${e.Message}");
                        }
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
