using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    public class MemberItemActivity
    {
        public LibraryItem Item { get; set; }
        public string Action { get; set; } // e.g., "Borrowed", "Reserved", "Returned"
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Action} \"{Item.Title}\" on {Date.ToShortDateString()}";
        }
    }
    public class LibraryMember
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<MemberItemActivity> memberActivities { get; set; } = new List<MemberItemActivity>();

        public string toString()
        {
            return $"{MemberId}: Name: {Name}, Contact: {Contact}";
        }

        public void BorrowItem(LibraryItem item)
        {
            if (item.ItemStatus == LibraryItem.Status.Available)
            {
                item.CheckOut();
                memberActivities.Add(new MemberItemActivity { Item = item, Action = "Borrowed", Date = DateTime.Now });
                Console.WriteLine($"Item \"{item.Title}\" borrowed successfully.");
            }
            else
            {
                Console.WriteLine($"Item \"{item.Title}\" is not available for borrowing.");
            }
        }
        public void ReturnItem(LibraryItem item)
        {
            if (item.ItemStatus == LibraryItem.Status.CheckedOut)
            {
                item.Return();
                memberActivities.Add(new MemberItemActivity { Item = item, Action = "Returned", Date = DateTime.Now });
                Console.WriteLine($"Item \"{item.Title}\" returned successfully.");
            }
            else
            {
                Console.WriteLine($"Item \"{item.Title}\" is not checked out.");
            }
        }
        public void ReserveItem(LibraryItem item)
        {
            if (item.ItemStatus == LibraryItem.Status.Available)
            {
                item.Reserve();
                memberActivities.Add(new MemberItemActivity { Item = item, Action = "Reserved", Date = DateTime.Now });
                Console.WriteLine($"Item \"{item.Title}\" reserved successfully.");
            }
            else
            {
                Console.WriteLine($"Item \"{item.Title}\" is not available for reservation.");
            }
        }
        public void ViewActivities()
        {
            if (memberActivities.Any())
            {
                Console.WriteLine($"Activities for {Name}:");
                foreach (var activity in memberActivities)
                {
                    Console.WriteLine(activity.ToString());
                }
            }
            else
            {
                Console.WriteLine($"No activities found for {Name}.");
            }
        }
    }
}
