using System.Collections.Generic;
using SmaProject.Models;

namespace SmaProject.Comparators
{
    public class EmployeeStartDateComparator : IComparer<EmployeeViewModel>
    {
        public int Compare(EmployeeViewModel x, EmployeeViewModel y)
        {
            if (x.StartDate > y.StartDate)
            {
                return 1;
            }
            else if (x.StartDate < y.StartDate)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
