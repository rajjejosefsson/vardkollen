using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using System.Data.Entity;
using System.Web.Mvc;
using vardkollen.KommunWebservice;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class EmployeesController : Controller
    {


        // TODO IMPLEMENT WCF 
        private readonly CareCheckDbContext _context = new CareCheckDbContext();
        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();


        // Index with employees table
        public ActionResult Index()
        {

            var viewModel = new EmployeeViewModel
            {
                Employees = _kommunWcfClient.EmployeeList()
            };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {


                var newEmployee = new Employee
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PersonNumber = viewModel.PersonNumber,
                    PhoneNumber = viewModel.PhoneNumber,
                    Adress = viewModel.Adress,
                    ZipCode = viewModel.ZipCode,
                };

                _kommunWcfClient.InsertOrUpdateEmployee(newEmployee);

                return RedirectToAction("Index");
            }

            // on failure - must get the list of employees from
            // db to get fetched to the table again
            viewModel.Employees = _kommunWcfClient.EmployeeList();

            return View("Index", viewModel);
        }



        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            _kommunWcfClient.DeletEmployee(id);
            return RedirectToAction("Index");
        }






















    }
}


