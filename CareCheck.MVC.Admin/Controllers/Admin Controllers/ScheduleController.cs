using CareCheck.DomainClasses;
using CareCheck.MVC.Admin.KommunWebservice;
using CareCheck.MVC.Admin.Models.CareCheckModels;
using CareCheck.MVC.Admin.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Admin_Controllers
{
    /* Contains the Employees schedule and Form to add schedule entries */
    public class ScheduleController : Controller
    {
        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();
        public ActionResult Index()
        {
            var patients = _kommunWcfClient.PatientList();
            var employees = _kommunWcfClient.EmployeeList();
            var taskItems = GetTaskModelCheckboxes();

            var viewModel = new CreateScheduleViewModel
            {
                Patients = patients,
                Employees = employees,
                PatientId = 0,
                EmployeeId = 0,
                Tasks = taskItems,
                Task = null
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchedule(CreateScheduleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var schedule = new Schedule
                {
                    DateTime = viewModel.DateTime,
                    PatientId = viewModel.PatientId,
                    EmployeeId = viewModel.EmployeeId
                };

                // First we either create or update the schedule
                var newSchedule = _kommunWcfClient.InsertOrUpdateSchedule(schedule);

                // Then we either create or updates its todolist 
                foreach (var task in viewModel.Tasks)
                {
                    if (task.IsChecked)
                    {
                        var todoItem = new TodoList()
                        {
                            TaskId = task.Id,
                            ScheduleId = newSchedule.Id,
                            IsDone = false // init value
                        };
                        _kommunWcfClient.InsertTodo(todoItem);
                    }
                }
                TempData["IsSuccess"] = true;
                return RedirectToAction("Index", "Schedule");
            }
            // To show the validation we need to pass this shit again
            viewModel.Tasks = GetTaskModelCheckboxes();
            viewModel.Patients = _kommunWcfClient.PatientList();
            viewModel.Employees = _kommunWcfClient.EmployeeList();

            return View("Index", viewModel);
        }


        // Generates the task checkboxes that we use to see if they are checked
        public List<TasksModel> GetTaskModelCheckboxes()
        {
            var tasks = _kommunWcfClient.TaskList();
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
            return taskItems;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchedule(int scheduleId)
        {
            _kommunWcfClient.DeleteSchedule(scheduleId);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult CreateTask(CreateScheduleViewModel viewModel)
        {
            var newTask = new Task
            {
                Name = viewModel.Task.Name
            };

            _kommunWcfClient.InsertOrUpdateTask(newTask);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult GetJsonSchedule()
        {
            List<Event> events = new List<Event>();
            var schedules = _kommunWcfClient.PatientsSchedules();

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


        // Must be named Id!
        public ActionResult BootstrapModal(int id)
        {
            var schedule = _kommunWcfClient.PatientScheduleById(id);
            var viewModel = new ScheduleItemViewModel
            {
                Patient = schedule.Patient,
                ScheduleId = schedule.Id,
            };
            return PartialView("_Modal", viewModel);
        }
    }
}