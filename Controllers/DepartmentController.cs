using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeDemo.EmployeeData;
using EmployeeDemo.Models;

namespace EmployeeDemo.Controllers
{
   
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentData _departmentData = null;
        public DepartmentController(IDepartmentData departmentData)
        {
            _departmentData = departmentData;

        }
                
        [HttpGet]
        [Route("api/Department/GetAllDepartment")]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentData.GetDepartments());

        }

        [HttpGet]
        [Route("api/Department/Get/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var dept = _departmentData.GetDepartment(id);
            if (dept != null)
            {
                return Ok(dept);
            }
            return NotFound($"Employee with the id: {id} was not found");

        }

        [HttpPost]
        [Route("api/Department/Add")]
        public IActionResult AddDepartment(Department dept)
        {
            _departmentData.AddDepartment(dept);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + dept.DeptId, dept);

        }

        [HttpDelete]
        [Route("api/Department/Delete/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _departmentData.GetDepartment(id);
            if (department != null)
            {
                _departmentData.DeleteDepartment(department);
                return Ok();
            }
            return NotFound($"Department with the id: {id} was not found");

        }

        [HttpPatch]
        [Route("api/Department/Edit/{id}")]
        public IActionResult EditDepartment(int id, Department dept)
        {
            var existingDepartment = _departmentData.GetDepartment(id);
            if (existingDepartment != null)
            {
                dept.DeptId = existingDepartment.DeptId;
                _departmentData.EditDepartment(dept);
                return Ok(dept);
            }

            return NotFound($"Department with the id: {id} was not found");

        }

    }
}