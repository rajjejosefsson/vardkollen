using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CareCheckDbContext _context = new CareCheckDbContext();


        // Index with employees table
        public ActionResult Index()
        {
            var viewModel = new EmployeeViewModel
            {
                Employees = _context.Employees.ToList()
            };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // if using create or edit
                if (viewModel.Id == 0)
                {
                    // CREATE Employee

                    var employee = new Employee
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PersonNumber = viewModel.PersonNumber,
                        PhoneNumber = viewModel.PhoneNumber,
                        Adress = viewModel.Adress,
                        ZipCode = viewModel.ZipCode,
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                }
                else
                {
                    // EDIT Employee

                    var employeeInDb = _context.Employees.Single(e => e.Id == viewModel.Id);

                    employeeInDb.FirstName = viewModel.FirstName;
                    employeeInDb.LastName = viewModel.LastName;
                    employeeInDb.PersonNumber = viewModel.PersonNumber;
                    employeeInDb.PhoneNumber = viewModel.PhoneNumber;
                    employeeInDb.Adress = viewModel.Adress;
                    employeeInDb.ZipCode = viewModel.ZipCode;
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // on failure - must get the list of employees from
            // db to get fetched to the table again
            viewModel.Employees = _context.Employees.ToList();

            return View("Index", viewModel);
        }



        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employeeInDb != null)
            {
                _context.Employees.Remove(employeeInDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }





















        /* WHEN TO USE FOLLOWING OR USE DTO ?? */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }






    }
}


