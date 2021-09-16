using System;

namespace Acme.BookStore.Employees
{
    internal class NameChangedEvent
    {
        public Guid EmpID { get; set; }
        public string NewName { get; set; }
    }
}