using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace Acme.BookStore.Employees
{
    class NameChangedEventHandler : ILocalEventHandler<NameChangedEvent>,
          ITransientDependency
    {
        private IEmployeeRepository _empRepo;
        public NameChangedEventHandler( IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        public async Task HandleEventAsync(NameChangedEvent eventData)
        {
            Employee emp =await  _empRepo.FindAsync(eventData.EmpID);
            if (emp != null)
            {
                emp.EmployeeName = eventData.NewName;
            }
        }
    }
}
