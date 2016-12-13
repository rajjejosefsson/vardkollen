using CareCheck.MVC.Admin.EmployeesWebservice;
using CareCheck.MVC.Admin.Models.CareCheckModels;
using CareCheck.MVC.Admin.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CareCheck.MVC.Admin.Controllers.Employees_Controllers
{

    /* View of an employees schedule and the patients tasks (Should be restricted for employees) */
    public class TaskController : Controller
    {
        private readonly EmployeesWebserviceClient _employeesWcfClient = new EmployeesWebserviceClient();

        public ActionResult Index()
        {
            // Employee is hardcoded with id 1 = Martin in Db
            var employeeSchedule = _employeesWcfClient.EmployeeSchedule(1);
            var employee = _employeesWcfClient.EmployeeById(1);

            var viewModel = new TasksViewModel
            {
                Schedules = employeeSchedule,
                Employee = employee
            };
            return View(viewModel);
        }


        // parameter must be called id for some reason..
        public ActionResult SelectSchedule(int id)
        {

            var schedule = _employeesWcfClient.PatientScheduleById(id);

            var taskItems = new List<TasksModel>();
            foreach (var todoListItem in schedule.TodoList)
            {
                taskItems.Add(new TasksModel()
                {
                    Id = todoListItem.Task.Id,
                    IsChecked = todoListItem.IsDone,
                    TaskName = todoListItem.Task.Name
                });
            }

            var viewModel = new TasksViewModel
            {
                Schedule = schedule,
                Tasks = taskItems,
                Medications = schedule.Patient.Medications.ToList()
            };

            return PartialView("_TaskPartialView", viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTodoList(TasksViewModel viewModel)
        {
            var scheduleId = viewModel.Schedule.Id;
            // send status of what boxes are selected
            var checkboxes = viewModel.Tasks.Select(t => t.IsChecked).ToArray();
            _employeesWcfClient.UpdateTodoList(scheduleId, checkboxes);

            return RedirectToAction("Index");
        }


    }
}