using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    static class LibraryStatistics
    {
        public static void LibraryStatistic (LibraryManager libraryManager, MemberManager memberManager)
        {
            Console.Clear();
            Console.WriteLine("---- LIBRARY STATISTICS ----");

            int totalItems = libraryManager.LibraryItems.Count;
            Console.WriteLine($"Total Library Items: {totalItems}");

            int totalBooks = libraryManager.LibraryItems.Count(item => item is Book);
            int totalMagazines = libraryManager.LibraryItems.Count(item => item is Magazine);
            int totalDigitalResources = libraryManager.LibraryItems.Count(item => item is DigitalResource);

            Console.WriteLine($"Total Books: {totalBooks}");
            Console.WriteLine($"Total Magazines: {totalMagazines}");
            Console.WriteLine($"Total Digital Resources: {totalDigitalResources}");

            int borrowedItems = libraryManager.LibraryItems.Count(item => item.ItemStatus == LibraryItem.Status.CheckedOut);
            Console.WriteLine($"Borrowed Items: {borrowedItems}");

            int availableItems = libraryManager.LibraryItems.Count(item => item.ItemStatus == LibraryItem.Status.Available);
            Console.WriteLine($"Available Items: {availableItems}");

            Console.WriteLine();
            int totalMembers = memberManager.LibraryMembers.Count;
            Console.WriteLine($"Total Registered Members: {totalMembers}");

            int membersWithBorrowedItems = memberManager.LibraryMembers.Count(member => member.memberActivities.Any(activity => activity.Action == "Borrowed"));
            Console.WriteLine($"Members with Borrowed Items: {membersWithBorrowedItems}");

            int membersWithReservedItems = memberManager.LibraryMembers.Count(member => member.memberActivities.Any(activity => activity.Action == "Reserved"));
            Console.WriteLine($"Members with Reserved Items: {membersWithReservedItems}");

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
