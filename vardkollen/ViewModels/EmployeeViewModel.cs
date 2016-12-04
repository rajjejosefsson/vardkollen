using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace vardkollen.ViewModels
{
    public class EmployeeViewModel
    {

        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}