using EmployeeDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDemo.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private mySampleDatabaseContext _employeeContext;
        public SqlEmployeeData(mySampleDatabaseContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public void AddEmployees(Employee employee)
        {
            _employeeContext.Employees.Add(employee);            
            _employeeContext.SaveChanges();            
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployees(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if(existingEmployee !=null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Dept = employee.Dept;
                _employeeContext.Employees.Update(existingEmployee);             
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public dynamic GetEmployees()
        {
            var employee = (from emp in _employeeContext.Employees
                        join dept in _employeeContext.Departments
                        on emp.Dept equals dept.DeptId
                        select new
                        {
                            emp.Id,
                            emp.Name,
                            dept.DeptId,
                            dept.DeptName
                        }).ToList().OrderByDescending(id=>id.Id);
            return employee;
            
        }
    }
}
