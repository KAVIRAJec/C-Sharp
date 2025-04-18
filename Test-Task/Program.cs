using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Task
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            List<LibraryItem> libraryItems =  new List<LibraryItem>();
            List<LibraryMember> libraryMembers = new List<LibraryMember>();
            (libraryItems, libraryMembers) = await DataHandler.LoadDataAsync();

            LibraryManager libraryManager = new LibraryManager(libraryItems);
            MemberManager memberManager = new MemberManager(libraryMembers);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("LIBRARY MANAGEMENT SYSTEM");
                Console.WriteLine("1. Item Management");
                Console.WriteLine("2. Member Management");
                Console.WriteLine("3. Checkout & Return Operations");
                Console.WriteLine("4. Search Library Catalog");
                Console.WriteLine("5. Save and Load Data");
                Console.WriteLine("6. Library Statistics");
                Console.WriteLine("7. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        ManageLibraryItems(libraryManager);
                        break;
                    case "2":
                        ManageLibraryMembers(memberManager);
                        break;
                    case "3":
                        ProcessCheckoutsAndReturns(libraryManager, memberManager);
                        break;
                    case "4":
                        ManageLibraryItem.SearchLibraryCatalog(memberManager);
                        break;
                    case "5":
                        await DataHandler.SaveAndLoadData(libraryManager, memberManager);
                        break;
                    case "6":
                        LibraryStatistics.LibraryStatistic(libraryManager, memberManager);
                        break;
                    case "7":
                        Console.WriteLine("Exiting the system!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        static void ManageLibraryItems(LibraryManager libraryManager)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("---- ITEM MANAGEMENT ----");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View All Items");
                Console.WriteLine("3. Search by Title");
                Console.WriteLine("4. Filter by Status");
                Console.WriteLine("5. Filter by Type");
                Console.WriteLine("6. Delete Item");
                Console.WriteLine("7. Back to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageLibraryItem.AddLibraryItem(libraryManager);
                        break;
                    case "2":
                        libraryManager.ViewAllItems();
                        break;
                    case "3":
                        Console.WriteLine("Enter the title to search: ");
                        string title = Console.ReadLine();
                        libraryManager.SearchByTitle(title);
                        break;
                    case "4":
                        ManageLibraryItem.FilterLibraryItemsByStatus(libraryManager);
                        break;
                    case "5":
                        ManageLibraryItem.FilterLibraryItemsByType(libraryManager);
                        break;
                    case "6":
                        ManageLibraryItem.DeleteLibraryItem(libraryManager);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }            
        }
        static void ManageLibraryMembers(MemberManager memberManager)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("---- MEMBER MANAGEMENT ----");
                Console.WriteLine("1. Register New Member");
                Console.WriteLine("2. View All Members");
                Console.WriteLine("3. View Borrowed Members");
                Console.WriteLine("4. Delete Member");
                Console.WriteLine("5. Back to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter member name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter contact details: ");
                        string contact = Console.ReadLine();
                        memberManager.AddMember(new LibraryMember { Name = name, Contact = contact });
                        break;
                    case "2":
                        Console.WriteLine("All Library Members:");
                        memberManager.ViewAllMembers();
                        break;
                    case "3":
                        Console.WriteLine("Borrowed Members:");
                        memberManager.ViewBorrowedMembers();
                        break;
                    case "4":
                        Console.Write("Enter member ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteMemberId))
                        {
                            if (memberManager.DeleteMember(deleteMemberId)) Console.WriteLine("Member deleted successfully.");
                            else Console.WriteLine("Member not found.");
                        }
                        else Console.WriteLine("Invalid member ID.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        static void ProcessCheckoutsAndReturns(LibraryManager libraryManager, MemberManager memberManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- CHECKOUT & RETURN OPERATIONS ----");
                Console.WriteLine("1. Checkout Item");
                Console.WriteLine("2. Return Item");
                Console.WriteLine("3. Reserve Item");
                Console.WriteLine("4. Check Due Date");
                Console.WriteLine("5. Back to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter member ID: ");
                        if (int.TryParse(Console.ReadLine(), out int memberId))
                        {
                            var member = memberManager.LibraryMembers.FirstOrDefault(m => m.MemberId == memberId);
                            if (member == null)
                            {
                                Console.WriteLine("Member not found.");
                                break;
                            }
                            Console.WriteLine("Available Library Items:");
                            libraryManager.FilterByStatus(LibraryItem.Status.Available);
                            Console.Write("Enter item ID to checkout: ");
                            if (int.TryParse(Console.ReadLine(), out int itemId))
                            {
                                var item = libraryManager.LibraryItems.FirstOrDefault(i => i.Id == itemId);
                                if (item == null || item.ItemStatus != LibraryItem.Status.Available)
                                {
                                    Console.WriteLine("Item not found/Available.");
                                }
                                else
                                {
                                    item.DueDateNotification += (message) => Console.WriteLine($"Notification: {message}");
                                    member.BorrowItem(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid item ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid member ID.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter member ID: ");
                        if (int.TryParse(Console.ReadLine(), out int returnMemberId))
                        {
                            var member = memberManager.LibraryMembers.FirstOrDefault(m => m.MemberId == returnMemberId);
                            if (member == null)
                            {
                                Console.WriteLine("Member not found.");
                                break;
                            }

                            Console.Write("Enter item ID to return: ");
                            if (int.TryParse(Console.ReadLine(), out int returnItemId))
                            {
                                var item = libraryManager.LibraryItems.FirstOrDefault(i => i.Id == returnItemId);
                                if (item == null || item.ItemStatus != LibraryItem.Status.CheckedOut)
                                {
                                    Console.WriteLine("Item not found/Available.");
                                }
                                else
                                {
                                    member.ReturnItem(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid item ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid member ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter member ID: ");
                        if (int.TryParse(Console.ReadLine(), out int reserveMemberId))
                        {
                            var member = memberManager.LibraryMembers.FirstOrDefault(m => m.MemberId == reserveMemberId);
                            if (member == null)
                            {
                                Console.WriteLine("Member not found.");
                                break;
                            }

                            Console.WriteLine("Available Library Items:");
                            libraryManager.FilterByStatus(LibraryItem.Status.Available);
                            Console.Write("Enter item ID to reserve: ");
                            if (int.TryParse(Console.ReadLine(), out int reserveItemId))
                            {
                                var item = libraryManager.LibraryItems.FirstOrDefault(i => i.Id == reserveItemId);
                                if (item == null || item.ItemStatus != LibraryItem.Status.Available)
                                {
                                    Console.WriteLine("Item not found/Available.");
                                }
                                else
                                {
                                    member.ReserveItem(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid item ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid member ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter member ID: ");
                        if (int.TryParse(Console.ReadLine(), out int dueDateMemberId))
                        {
                            var member = memberManager.LibraryMembers.FirstOrDefault(m => m.MemberId == dueDateMemberId);
                            if (member == null)
                            {
                                Console.WriteLine("Member not found.");
                                break;
                            }
                            Console.WriteLine("List of Items you borrowed: ");
                            foreach (var activity in member.memberActivities)
                            {
                                if (activity.Action == "Borrowed")
                                {
                                    Console.WriteLine($"{activity.Item.Title} {activity.Item.Type} {activity.Item.DueDate.Value.ToShortDateString()}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid member ID.");
                        }
                        break;
                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
