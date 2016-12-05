using CareCheck.DataAccess;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.ViewModels;


namespace vardkollen.Controllers
{
    public class TaskController : Controller
    {

        private readonly CareCheckDbContext _context = new CareCheckDbContext();

        public ActionResult Index()
        {

            var employeeSchedules = _context.Schedules.Where(s => s.EmployeeId == 1)
                .Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();


            var viewModel = new EmployeeSheduleTasksViewModel
            {
                Schedules = employeeSchedules
            };


            return View(viewModel);
        }




        public ActionResult MyAction(int? id)
        {
            var schedule = _context.Schedules.Where(s => s.Id == id)
                                             .Include(t => t.TodoList.Select(i => i.Task))
                                             .Single();


            var viewModel = new EmployeeSheduleTasksViewModel
            {
                Schedule = schedule
            };

            return PartialView("_TaskPartialView", viewModel);
        }


    }
}