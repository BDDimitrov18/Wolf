using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.ViewModels
{
    public class EmployeeListItem
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }

        // Override ToString to return FullName, which will be displayed in the CheckedListBox
        public override string ToString()
        {
            return FullName;
        }

        public bool IsSelected { get; set; }
    }

}
