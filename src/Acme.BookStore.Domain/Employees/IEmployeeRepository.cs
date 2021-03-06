using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        Task<Employee> FindByNameAsync(string name);

        Task<List<Employee>> FindByAgeAsync(int Age = -1);

        Task<List<Employee>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
        Task ChangeNameAsync( [NotNull] Employee emp, [NotNull] string newName);  
    }
}
