using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeDemo.EmployeeData;
using EmployeeDemo.Models;


namespace EmployeeDemo.Controllers
{    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private readonly IEmployeeData _employeeData = null;
      
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
            
        }
               
        [HttpGet]
        [Route("api/Employee/GetAllEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
                    
        }
        
        [HttpGet]
        [Route("api/Employee/Get/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee!=null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with the id: {id} was not found");

        }

        [HttpPost]
        [Route("api/Employee/Add")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployees(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                 _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with the id: {id} was not found");

        }

        [HttpPatch]
        [Route("api/Employee/Edit/{id}")]
        public IActionResult EditEmployee(int id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployees(employee);
                return Ok(employee);
            }
         
            return NotFound($"Employee with the id: {id} was not found");

        }
    }
}