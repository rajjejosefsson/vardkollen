using CareCheck.DataAccess;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.Models;
using vardkollen.ViewModels;

namespace vardkollen.Controllers
{
    public class ScheduleController : Controller
    {

        private readonly CareCheckDbContext _context = new CareCheckDbContext();

        public ActionResult Index()
        {

            var patients = _context.Patients.ToList();
            var employees = _context.Employees.ToList();
            var tasks = _context.Tasks.ToList();



            var taskItems = new List<TasksModel>();
            foreach (var task in tasks)
            {
                taskItems.Add(new TasksModel()
                {
                    Id = task.Id,
                    IsChecked = false,
                    TaskName = task.Name
                });
            }


            var viewModel = new CreateScheduleViewModel
            {
                Patients = patients,
                Employees = employees,
                PatientId = 0,
                EmployeeId = 0,
                Tasks = taskItems,
            };


            return View(viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchedule(CreateScheduleViewModel viewModel)
        {

            // DateTime  PatientID   EmployeeId
            Schedule schedule = new Schedule
            {
                DateTime = viewModel.DateTime,
                PatientId = viewModel.PatientId,
                EmployeeId = viewModel.EmployeeId
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();  // we do have schedule.Id from db now allready.




            // Task_id     Schedule_id    isDone
            foreach (var task in viewModel.Tasks)
            {
                if (task.IsChecked)
                {
                    var todoItem = new TodoList()
                    {
                        TaskId = task.Id,
                        ScheduleId = schedule.Id,
                        IsDone = false // init value
                    };
                    _context.TodoList.Add(todoItem);
                }
            }
            _context.SaveChanges();


            return RedirectToAction("Index");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchedule(int? scheduleId)
        {


            // Check if schedule exists
            var schedule = _context.Schedules.Single(e => e.Id == scheduleId);

            // Get todolist items from the selected schedule
            var todoList = _context.TodoList.Where(t => t.ScheduleId == schedule.Id).ToList();

            // remove each item in the list
            foreach (var item in todoList)
            {
                _context.TodoList.Remove(item);
            }


            // remove the schedule from db
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }




        public ActionResult UpdateSchedule(string s)
        {
            throw new System.NotImplementedException();
        }





        [HttpGet]
        public JsonResult GetJsonSchedule()
        {
            List<Event> events = new List<Event>();
            var schedules = _context.Schedules.Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();

            foreach (var schedule in schedules)
            {
                events.Add(new Event()
                {
                    id = schedule.Id,
                    title = schedule.Patient.FirstName,
                    start = schedule.DateTime.ToString(),
                });
            }
            return Json(events, JsonRequestBehavior.AllowGet);
        }





        public ActionResult BootstrapModal(int? id)
        {
            var schedule = _context.Schedules.Where(s => s.Id == id)
                                 .Include(p => p.Patient).Include(t => t.TodoList.Select(i => i.Task))
                                 .Single();



            var taskItems = new List<TasksModel>();
            foreach (var listItem in schedule.TodoList)
            {
                taskItems.Add(new TasksModel()
                {
                    Id = listItem.Id,
                    IsChecked = false,
                    TaskName = listItem.Task.Name
                });
            }




            var viewModel = new ScheduleItemViewModel
            {
                Patient = schedule.Patient,
                ScheduleId = schedule.Id,
                Tasks = taskItems

            };

            return PartialView("_Modal", viewModel);
        }









    }
}