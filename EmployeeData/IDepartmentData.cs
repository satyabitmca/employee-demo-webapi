using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDemo.Models;

namespace EmployeeDemo.EmployeeData
{
   public interface IDepartmentData
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        void AddDepartment(Department dept);
        Department EditDepartment(Department dept);
        void DeleteDepartment(Department dept);
    }
}
