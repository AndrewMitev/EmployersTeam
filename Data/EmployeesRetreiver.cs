using Data.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public class EmployeesRetreiver
    {
        private readonly HashSet<int> projectIDs = new HashSet<int>();
        private readonly List<Employee> employess = new List<Employee>();

        private readonly string path = @"Data\Data.txt";

        public EmployeesRetreiver()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null && line != string.Empty)
                {
                    string[] fields = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(m => m.Trim())
                        .ToArray();

                    int projectID = int.Parse(fields[1]);
                    DateTime endDate;

                    if (fields[3] == "NULL")
                    {
                        endDate = DateTime.Now;
                    }
                    else
                    {
                        endDate = DateTime.Parse(fields[3]);
                    }

                    Employee emp = new Employee
                    {
                        EmployeeID = long.Parse(fields[0]),
                        ProjectID = projectID,
                        StartDate = DateTime.Parse(fields[2]),
                        EndDate = endDate
                    };

                    projectIDs.Add(projectID);
                    employess.Add(emp);
                }

            }
        }

        public HashSet<int> GetAllProjectIDs()
        {
            return this.projectIDs;
        }

        public List<Employee> GetAllEmployessPerProject(int projectID)
        {
            List<Employee> filtered = new List<Employee>();

            foreach (var employee in employess)
            {
                if (employee.ProjectID == projectID
                    && !filtered.Contains(employee))
                {
                    filtered.Add(employee);
                }
            }

            return filtered;
        }
    }
}
