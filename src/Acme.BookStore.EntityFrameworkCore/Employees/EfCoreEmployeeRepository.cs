using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Acme.BookStore.Employees;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Authors
{
    public class EfCoreEmployeeRepository
        : EfCoreRepository<BookStoreDbContext, Employee, Guid>,
            IEmployeeRepository
    {
        public EfCoreEmployeeRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task ChangeNameAsync(
            [NotNull] Employee emp,
            [NotNull] string newName)
        {
            Check.NotNull(emp, nameof(emp));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));
            var dbSet = await GetDbSetAsync();

            Employee emp1 = await dbSet.FindAsync(emp.Id);
            if (emp1 != null)
                emp.ChangeName(newName);
        }

        public async Task<List<Employee>> FindByAgeAsync(int Age = -1)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where
                (
                    new SalaryPlus10KEmployeeSpecification()
                    .And(new PlusXAgeSpicification(Age))
                    .ToExpression()
                ).ToListAsync();
        }
        public async Task<Employee> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(author => author.EmployeeName == name);
        }
        


        public async Task<List<Employee>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.EmployeeName.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

    }
}
