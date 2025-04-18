using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    internal class Book:LibraryItem
    {
        public string Genre { get; set; }
        public int PageCount { get; set; }

        public override string GetItemDetails()
        {
            return $"{base.GetItemDetails()} \n Genre: {Genre}, Pages: {PageCount}";
        }   
    }
}
