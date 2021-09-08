using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;

namespace Acme.BookStore.Employees
{
    public interface IEmployeeAppService : ICrudAppService< //Defines CRUD methods
            EmployeeDto, //Used to show Employees
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateEmployeeDto> //Used to create/update a book
    {
    }
}
