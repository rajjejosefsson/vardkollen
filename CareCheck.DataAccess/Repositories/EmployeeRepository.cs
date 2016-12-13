using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {


        public ICollection<Employee> EmployeeList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Employees.AsNoTracking().ToList();
            }
        }


        public Employee FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Employees.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }


        public void InsertOrUpdate(Employee employee)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                // if using create or edit
                if (employee.Id == 0)
                {
                    // CREATE Employee
                    context.Employees.Add(employee);
                }
                else
                {
                    // EDIT Employee
                    var employeeInDb = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                    employeeInDb.FirstName = employee.FirstName;
                    employeeInDb.LastName = employee.LastName;
                    employeeInDb.PersonNumber = employee.PersonNumber;
                    employeeInDb.PhoneNumber = employee.PhoneNumber;
                    employeeInDb.Adress = employee.Adress;
                    employeeInDb.ZipCode = employee.ZipCode;
                }

                context.SaveChanges();
            }
        }


        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                // Get employee by id
                var employeeInDb = context.Employees.SingleOrDefault(e => e.Id == id);
                context.Employees.Remove(employeeInDb);
                context.SaveChanges();
            }
        }


    }
}