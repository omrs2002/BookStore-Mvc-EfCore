using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Employees
{
    public class PlusXAgeSpicification : Specification<Employee>
    {
        public int Age { get; }

        public PlusXAgeSpicification(int XAge)
        {
            Age = XAge;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return i => i.Age >= Age;
        }
    }
}
