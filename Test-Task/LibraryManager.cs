using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    public class LibraryManager
    {
        public List<LibraryItem> LibraryItems { get; set; } = new List<LibraryItem>();
        private int id = 0;
        public LibraryManager(List<LibraryItem> items)
        {
            LibraryItems = items;
            id = LibraryItems.Any() ? LibraryItems.Count() : 0;
        }
        public void AddItem(LibraryItem item)
        {
            if (item != null)
            {
                item.Id = ++id;
                LibraryItems.Add(item);
                Console.WriteLine("Item added Successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }
        public void ViewAllItems()
        {
            foreach(var item in LibraryItems)
            {
                Console.WriteLine(item.GetItemDetails());
            }
        }
        public void SearchByTitle(string title)
        {
            var item = from LibraryItem in LibraryItems
                       where LibraryItem.Title == title
                       select LibraryItem;
            if (item.Any())
            {
                Console.WriteLine($"Item Found by {title}:");
                foreach (var i in item)
                {
                    Console.WriteLine(i.GetItemDetails());
                }
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }
        public void FilterByStatus(LibraryItem.Status status)
        {
            var item = LibraryItems.Where(i => i.ItemStatus == status);
            if (item.Any())
            {
                Console.WriteLine($"Items with status {status}:");
                foreach (var i in item)
                {
                    Console.WriteLine(i.GetItemDetails());
                }
            }
            else
            {
                Console.WriteLine("No items found with the specified status.");
            }
        }
        public void FilterByType<T>() where T : LibraryItem
        {
            var item = LibraryItems.OfType<T>();
            if (item.Any())
            {
                Console.WriteLine($"Items of type {typeof(T).Name}:");
                foreach (var i in item)
                {
                    Console.WriteLine(i.GetItemDetails());
                }
            }
            else
            {
                Console.WriteLine("No items found of the specified type.");
            }
        }
        public bool DeleteItem(LibraryItem item)
        {
            if (item != null && LibraryItems.Contains(item))
            {
                LibraryItems.Remove(item);
                Console.WriteLine("Item deleted successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Item not found");
                return false;
            }
        }
    }
}
