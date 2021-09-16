using System;
using System.Threading.Tasks;
using Acme.BookStore.Employees;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class EmployeeManager : DomainService
    {
        private readonly IEmployeeRepository _empRepository;


        public EmployeeManager(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        public async Task<Author> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingemp = await _empRepository.FindByNameAsync(name);
            if (existingemp != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }

            return new Author(
                GuidGenerator.Create(),
                name,
                birthDate,
                shortBio
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Employee emp,
            [NotNull] string newName)
        {
            Check.NotNull(emp, nameof(emp));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            Employee emp1 = await _empRepository.FindAsync(emp.Id);
            if(emp1 != null)
                emp.ChangeName(newName);
        }
    }
}
