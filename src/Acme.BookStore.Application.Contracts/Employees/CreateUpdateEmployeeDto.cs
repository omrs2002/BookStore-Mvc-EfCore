using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Employees
{
    public class CreateUpdateEmployeeDto
    {
        
        [Required]
        [StringLength(128)]
        public string EmployeeName { get; set; }


        [Required]
        public float Salary { get; set; }

    }
}