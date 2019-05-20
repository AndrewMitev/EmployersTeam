using System.Linq;
using System.Collections.Generic;

namespace SmaProject.Helpers
{
    public class EmployeesRelationList
    {
        private readonly List<EmployeeRelation> employeesRelationList;

        public EmployeesRelationList()
        {
            this.employeesRelationList = new List<EmployeeRelation>();
        }

        internal void Add(List<EmployeeRelation> empRelationListAdded)
        {
            foreach (var empRelation in empRelationListAdded)
            {
                long firstKey = empRelation.FirstEmployeeID;
                long secondKey = empRelation.SecondEmployeeID;

                if (employeesRelationList.Any(er => er.FirstEmployeeID == firstKey 
                    && er.SecondEmployeeID == secondKey))
                {
                    employeesRelationList.Single(er => er.FirstEmployeeID == firstKey
                        && er.SecondEmployeeID == secondKey)
                        .WorkingDaysTogether += empRelation.WorkingDaysTogether;
                }
                else
                {
                    employeesRelationList.Add(new EmployeeRelation
                    {
                        FirstEmployeeID = firstKey,
                        SecondEmployeeID = secondKey,
                        WorkingDaysTogether = empRelation.WorkingDaysTogether
                    });
                }
            }
        }

        internal (long emp1, long emp2) GetResult()
        {
            long firstemployeeID = -1;
            long secondEmployeeID = -1;
            int maxDays = 0;

            foreach (var empWorkingDaysRelation in employeesRelationList)
            {
                int workingDaysTogether = empWorkingDaysRelation.WorkingDaysTogether;

                if (workingDaysTogether > maxDays)
                {
                    maxDays = workingDaysTogether;
                    firstemployeeID = empWorkingDaysRelation.FirstEmployeeID;
                    secondEmployeeID = empWorkingDaysRelation.SecondEmployeeID;
                }
            }

            return (firstemployeeID, secondEmployeeID);
        }
    }
}
