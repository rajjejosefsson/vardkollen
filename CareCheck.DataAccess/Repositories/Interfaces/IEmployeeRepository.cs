using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> EmployeeList();
        Employee FindById(int id);
        void InsertOrUpdate(Employee employee);
        void DeleteById(int id);
    }
}
