using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Acme.BookStore.Authors;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
using Volo.Abp.Uow;

namespace Acme.BookStore.Employees
{
    [UnitOfWork]
    public class EmployeeAppService :
        CrudAppService<
            Employee, //The Employee entity
            EmployeeDto, //Used to show Employees
            Guid, //Primary key of the Employee entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateEmployeeDto>, //Used to create/update a Employee
        IEmployeeAppService //implement the IEmployeeAppService,
    {

        IRepository<Employee, Guid> _repository;
        IEmployeeRepository _rep;
        //private readonly IUnitOfWorkManager _unitOfWorkManager;


        public EmployeeAppService(
            IRepository<Employee, Guid> repository,
            IEmployeeRepository emp_rep
            ) : base(repository)
        {
            _repository = repository;
            _rep = emp_rep;
        }

        /// <summary>
        /// Use Unit of work
        /// </summary>
        /// <param name="empID">Employee ID</param>
        /// <returns></returns>
        public async Task<bool> SetEmployeeToManager(Guid empID)
        {
            try
            {
                using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
                {
                    var employee = await _repository.GetAsync(empID, false);
                    if (employee != null)
                    {
                        employee.Salary = employee.Salary + (employee.Salary * 0.15f);
                    }

                    

                    _ = await _repository.UpdateAsync(employee);

                    await uow.SaveChangesAsync();

                    await uow.CompleteAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }


       
        public async Task<bool> ChangeEmployeeName(Guid empID,string newName)
        {
            try
            {
                    Employee employee = await _repository.GetAsync(empID, false);
                    if (employee != null)
                    {
                        employee.ChangeName(newName);
                    }

                    //_ = await _repository.UpdateAsync(employee);

                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }



        public async Task<List<Employee>> FindByAgeAsync(int Age = -1)
        {
            return await _rep.FindByAgeAsync(Age);
        }

    }
}
