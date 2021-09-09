using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Employees
{
    public class SalaryPlus10KEmployeeSpecification : Specification<Employee>
    {
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return c => c.Salary >= 10000;
        }
    }

}
