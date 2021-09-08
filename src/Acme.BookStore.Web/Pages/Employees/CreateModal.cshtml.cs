using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Employees
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateEmployeeViewModel Employee { get; set; }

        private readonly IEmployeeAppService _employeeAppService;

        public CreateModalModel(
            IEmployeeAppService bookAppService)
        {
            _employeeAppService = bookAppService;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.CreateAsync(
                ObjectMapper.Map<CreateEmployeeViewModel, CreateUpdateEmployeeDto>(Employee)
                );
            return NoContent();
        }

        public class CreateEmployeeViewModel
        {
            [Required]
            [StringLength(128)]
            public string EmployeeName { get; set; }

            [Required]
            public float Salary { get; set; }
        }
    }
}