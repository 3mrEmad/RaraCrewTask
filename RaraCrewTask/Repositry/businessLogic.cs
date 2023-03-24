using RaraCrewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaraCrewTask.Business
{
    public class businessLogic
    {

        public List<Employee> FilterEmployeesByName(List<Employee> emps)
        {
            List<Employee> filterdList = new List<Employee>();
            foreach (var emp in emps)
            {
                var EmployeeFromList = filterdList.Find(e => e.EmployeeName == emp.EmployeeName);
                if (EmployeeFromList == null)
                {
                    var employee = new Employee()
                    {
                        EmployeeName = emp.EmployeeName,
                        TimeWorked = CalculateNumberOfHours(emp.EndTimeUtc, emp.StarTimeUtc)
                    };
                    filterdList.Add(employee);
                }
                else
                {

                    EmployeeFromList.TimeWorked += CalculateNumberOfHours(emp.EndTimeUtc, emp.StarTimeUtc);

                }
            }
            return filterdList;
        }
             






       private double CalculateNumberOfHours(string EndTimeUtc, string StarTimeUtc)
        {
            DateTime convertedDate1 = DateTime.Parse(StarTimeUtc);
            DateTime convertedDate2 = DateTime.Parse(EndTimeUtc);
            double hours = (convertedDate2 - convertedDate1).TotalHours;
            return hours;
        }




        

    }
}
