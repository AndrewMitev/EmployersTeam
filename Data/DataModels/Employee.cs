using System;

namespace Data.DataModels
{
    public class Employee : IEquatable<Employee>
    {
        public long EmployeeID { get; set; }

        public int ProjectID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Equals(Employee other)
        {
            return this.EmployeeID == other.EmployeeID
                && this.ProjectID == other.ProjectID
                && this.StartDate == other.StartDate
                && this.EndDate == other.EndDate;
        }
    }
}
