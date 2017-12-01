using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{


    class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            int numberOfEmployees = int.Parse(Console.ReadLine());
            var allEnEmployees = new List<Employee>();
            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] empInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Employee newEmployee = new Employee(empInfo[0], decimal.Parse(empInfo[1]), empInfo[2], empInfo[3]);
                if (empInfo.Length > 5)
                {
                    if (empInfo[5].Contains("@"))
                    {
                        newEmployee.email = empInfo[5];
                    }
                    else
                    {
                        newEmployee.age = int.Parse(empInfo[5]);
                    }
                }

                if (empInfo.Length > 4)
                {
                    if (empInfo[4].Contains("@"))
                    {
                        newEmployee.email = empInfo[4];
                    }
                    else
                    {
                        newEmployee.age = int.Parse(empInfo[4]);
                    }
                }
                allEnEmployees.Add(newEmployee);
            }
            var sortedDepartment = allEnEmployees.GroupBy(emp => emp.department)
                                                  .OrderByDescending(d => d.Average(p => p.salary))
                                                  .FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {sortedDepartment.Key}");

            sortedDepartment.Select(p => new { p.name, p.salary, p.email, p.age })
                            .OrderByDescending(emp => emp.salary)
                            .ToList()
                            .ForEach(emp => Console.WriteLine($"{emp.name} {emp.salary:F2} {emp.email} {emp.age}"));
        }
    }
    public class Employee
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee()
        {
            this.email = "n/a";
            this.age = -1;
        }
        public Employee(string name, decimal salary, string position, string department)
            : this()
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
        }
    }

}
    

