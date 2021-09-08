using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public string Department { get { return EmployeeName + " - Department"; }  }
    }
}