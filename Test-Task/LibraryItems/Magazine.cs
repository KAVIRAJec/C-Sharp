using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    internal class Magazine: LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        public override string GetItemDetails()
        {
            return $"{base.GetItemDetails()} \n Issue: {IssueNumber}, Publisher: {Publisher}";
        }
    }
}
