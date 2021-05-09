using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeDemo.Models
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name can only be 50 characters long")]
        public string Name { get; set; }
        public int? Dept { get; set; }

        public virtual Department DeptNavigation { get; set; }
    }
}
