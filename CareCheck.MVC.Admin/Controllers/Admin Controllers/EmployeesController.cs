using AutoMapper;
using CareCheck.DomainClasses;
using CareCheck.MVC.Admin.KommunWebservice;
using CareCheck.MVC.Admin.ViewModels;
using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Admin_Controllers
{
    /* Contains the Employee Form and the employee Table */
    public class EmployeesController : Controller
    {
        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();

        public ActionResult Index()
        {
            var viewModel = new CreateEmployeeViewModel
            {
                Employees = _kommunWcfClient.EmployeeList()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUpdateEmployee(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                /* Auto maps eg. FirstName = viewModel.FirstName ect, */
                var newEmployee = Mapper.Map<CreateEmployeeViewModel, Employee>(viewModel);

                _kommunWcfClient.InsertOrUpdateEmployee(newEmployee);

                TempData["IsSuccess"] = true;
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


