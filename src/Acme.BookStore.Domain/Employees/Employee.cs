using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public float Salary { get; set; }
    }
}
