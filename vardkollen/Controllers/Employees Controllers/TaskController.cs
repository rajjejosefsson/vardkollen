using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using vardkollen.KommunWebservice;
using vardkollen.Models;
using vardkollen.ViewModels;


namespace vardkollen.Controllers
{
    public class TaskController : Controller
    {

        private readonly KommunWebserviceClient _kommunWcfClient = new KommunWebserviceClient();

        public ActionResult Index()
        {

            // Employee is hardcoded with id 1 = Martin in Db
            var employeeSchedule = _kommunWcfClient.EmployeeSchedule(1);


            var employee = _kommunWcfClient.EmployeeById(1);


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

            var schedule = _kommunWcfClient.PatientScheduleById(id);



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
            _kommunWcfClient.UpdateTodoList(scheduleId, checkboxes);

            return RedirectToAction("Index");
        }


    }
}