using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    internal class DigitalResource: LibraryItem
    {
        public string Format { get; set; }
        public double FileSize { get; set; }

        public override string GetItemDetails()
        {
            return $"{base.GetItemDetails()} \n Format: {Format}, File Size: {FileSize}MB";
        }
    }
}
