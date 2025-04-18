using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public enum Status
        {
            Available,
            CheckedOut,
            OnHold
        }
        public Status ItemStatus { get; set; } = Status.Available;
        public DateTime? DueDate { get; set; } = null;
        public event Action<string> DueDateNotification;
        public string Type => GetType().Name;

        public virtual void CheckOut()
        {
            ItemStatus = Status.CheckedOut;
            DueDate = DateTime.Now.AddDays(14); // Assuming a 2-week checkout period
            DueDateNotification?.Invoke($"Due date for {Title} is {DueDate.Value.ToShortDateString()}");
        }
        public virtual void Return()
        {
            ItemStatus = Status.Available;
            DueDate = null;
        }
        public virtual void Reserve()
        {
            ItemStatus = Status.OnHold;
        }
        public virtual string GetItemDetails()
        {
            return $"{Id}: Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, Status: {ItemStatus}";
        }

        public static implicit operator List<object>(LibraryItem v)
        {
            throw new NotImplementedException();
        }
    }
}
