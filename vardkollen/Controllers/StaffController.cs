using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class StaffController : Controller
    {
        private readonly CareCheckDbContext _context = new CareCheckDbContext();


        // GET: Staff
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
        public ActionResult CreateEmployee(Employee employee)
        {

            // Check if user exist - if true - update
            // if not - create new 




            if (employee.Id == 0)
            {
                // CREATE - is new employe
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            else
            {
                var employeeInDb = _context.Employees.Single(e => e.Id == employee.Id);

                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;
                employeeInDb.PersonNumber = employee.PersonNumber;
                employeeInDb.PhoneNumber = employee.PhoneNumber;
                employeeInDb.Adress = employee.Adress;
                employeeInDb.ZipCode = employee.ZipCode;
            }



            _context.SaveChanges();


            return RedirectToAction("Index");
        }





        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.Single(e => e.Id == id);

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

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


