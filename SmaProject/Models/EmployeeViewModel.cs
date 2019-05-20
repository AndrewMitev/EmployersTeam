using System;

namespace SmaProject.Models
{
    public class EmployeeViewModel
    {
        public long EmployeeID { get; set; }

        public int ProjectID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
