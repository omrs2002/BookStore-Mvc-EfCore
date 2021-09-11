using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Employees
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditEmployeeViewModel Employee { get; set; }

        public List<SelectListItem> Authors { get; set; }

        private readonly IEmployeeAppService _empAppService;

        public EditModalModel(IEmployeeAppService empAppService)
        {
            _empAppService = empAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var bookDto = await _empAppService.GetAsync(id);
            Employee = ObjectMapper.Map<EmployeeDto, EditEmployeeViewModel>(bookDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _empAppService.UpdateAsync(
                Employee.Id,
                ObjectMapper.Map<EditEmployeeViewModel, CreateUpdateEmployeeDto>(Employee)
            );

            return NoContent();
        }

        public class EditEmployeeViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }


            [Required]
            [StringLength(128)]
            public string EmployeeName { get; set; }


            [Required]
            public float Salary { get; set; }

            [Required]
            public int Age { get; set; }

        }
    }
}