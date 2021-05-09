using EmployeeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {

            new Employee()
            {
                Id =1, Name="Mark"
            },

            new Employee()
            {
                Id =2, Name="Mike"
            },

            new Employee()
            {
                Id =3, Name="Mary"
            }
        };


        public void AddEmployees(Employee employee)
        {
            employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployees(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public Employee GetEmployee(int id)
        {
            return employees.SingleOrDefault(e => e.Id == id);
        }

        public dynamic GetEmployees()
        {
            return employees;
        }
    }
}
