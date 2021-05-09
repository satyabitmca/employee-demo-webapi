using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeDemo.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int DeptId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "DeptName can only be 50 characters long")]
        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
