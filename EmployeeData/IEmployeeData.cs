using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDemo.Models;

namespace EmployeeDemo.EmployeeData
{
   public interface IEmployeeData
    {
        dynamic GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployees(Employee employee);
        Employee EditEmployees(Employee employee);
        void DeleteEmployee(Employee employee);



    }
}
