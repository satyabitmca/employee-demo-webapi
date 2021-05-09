using EmployeeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.EmployeeData
{
    public class SqlDepartmentData : IDepartmentData
    {
        private mySampleDatabaseContext _departmentContext;

        public SqlDepartmentData(mySampleDatabaseContext departmentContext)
        {
            _departmentContext = departmentContext;

        }
        public List<Department> GetDepartments()
        {
            return  _departmentContext.Departments.ToList().OrderByDescending(id => id.DeptId).ToList();            
        }

        public void AddDepartment(Department dept)
        {
            _departmentContext.Departments.Add(dept);
            _departmentContext.SaveChanges();

        }

        public void DeleteDepartment(Department dept)
        {
            _departmentContext.Departments.Remove(dept);
            _departmentContext.SaveChanges();
        }

        public Department EditDepartment(Department dept)
        {
            var existingDepartment = _departmentContext.Departments.Find(dept.DeptId);
            if (existingDepartment != null)
            {
                existingDepartment.DeptName = dept.DeptName;
                _departmentContext.Departments.Update(existingDepartment);
                _departmentContext.SaveChanges();
            }
            return dept;
        }

        public Department GetDepartment(int id)
        {
            var dept = _departmentContext.Departments.Find(id);
            return dept;
        }
    }
}
