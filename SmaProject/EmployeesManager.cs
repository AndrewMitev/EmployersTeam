using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using SmaProject.Comparators;
using SmaProject.Helpers;
using SmaProject.Models;

namespace SmaProject
{
    public class EmployeesManager
    {
        private EmployeesRelationList finalList = new EmployeesRelationList();
        private EmployeesRetreiver employeesRetreiver = new EmployeesRetreiver();

        private readonly HashSet<int> projectIDs;

        public EmployeesManager()
        {
            this.projectIDs = employeesRetreiver.GetAllProjectIDs();
        }

        public void Initialize()
        {
            foreach (int projectID in projectIDs)
            {
                List<EmployeeViewModel> employeesPerProject = employeesRetreiver.GetAllEmployessPerProject(projectID)
                    .Select(emp => new EmployeeViewModel
                    {
                        EmployeeID = emp.EmployeeID,
                        ProjectID = emp.ProjectID,
                        StartDate = emp.StartDate,
                        EndDate = emp.EndDate
                    }).ToList();

                List<EmployeeRelation> currentList = GetCombinationsForEmployees(employeesPerProject);
                finalList.Add(currentList);
            }
        }

        internal (long, long) GetResult()
        {
            return finalList.GetResult();
        }

        private List<EmployeeRelation> GetCombinationsForEmployees(List<EmployeeViewModel> employeesPerProject)
        {
            List<EmployeeRelation> matches = new List<EmployeeRelation>();
            employeesPerProject.Sort(new EmployeeStartDateComparator());

            for (int i = 0; i < employeesPerProject.Count - 1; i++)
            {
                for (int j = i + 1; j < employeesPerProject.Count; j++)
                {
                    if (employeesPerProject[i].EndDate > employeesPerProject[j].StartDate)
                    {
                        int workingDaysTogether;
                        if (employeesPerProject[i].EndDate < employeesPerProject[j].EndDate)
                        {
                            workingDaysTogether = (employeesPerProject[i].EndDate - employeesPerProject[j].StartDate).Days;
                        }
                        else
                        {
                            workingDaysTogether = (employeesPerProject[j].EndDate - employeesPerProject[j].StartDate).Days;
                        }

                        matches.Add(new EmployeeRelation
                        {
                            FirstEmployeeID = employeesPerProject[i].EmployeeID,
                            SecondEmployeeID = employeesPerProject[j].EmployeeID,
                            WorkingDaysTogether = workingDaysTogether
                        });
                    }
                }
            }

            return matches;
        }
    }
}
