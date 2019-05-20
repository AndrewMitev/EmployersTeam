using System;

namespace SmaProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeesManager employeesManager = new EmployeesManager();
            employeesManager.Initialize();

            Print(employeesManager.GetResult);
        }

        static void Print(Func<(long, long)> func)
        {
            (long employeeOneID, long employeeTwoID) = func();

            if (employeeOneID == -1 && employeeTwoID == -1)
            {
                Console.WriteLine("None has worked together!");
            }
            else
            {
                Console.WriteLine($"EmployeeOneID {employeeOneID} : EmployeeTwoID {employeeTwoID}");
            }
        }
    }
}
