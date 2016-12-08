using CareCheck.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vardkollen.Models;
using vardkollen.ViewModels;


namespace vardkollen.Controllers
{
    public class TaskController : Controller
    {

        private readonly CareCheckDbContext _context = new CareCheckDbContext();

        public ActionResult Index()
        {

            // Employee is hardcoded with id 1 = Martin in Db
            var schedulesAndPatient = _context.Schedules.Where(e => e.EmployeeId == 1)
                                                        .OrderByDescending(s => s.DateTime)
                                                        .Include(p => p.Patient)
                                                        .Include(e => e.Employee)
                                                        .ToList();


            var employee = _context.Employees.Single(e => e.Id == 1);


            var viewModel = new TasksViewModel
            {
                Schedules = schedulesAndPatient,
                Employee = employee
            };

            return View(viewModel);
        }




        public ActionResult SelectSchedule(int? id)
        {

            var schedule = _context.Schedules.Where(s => s.Id == id)
                                             .Include(t => t.TodoList.Select(i => i.Task))
                                             .Include(p => p.Patient.Medications)
                                             .Single();






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


            var dataEntries = _context.TodoList.Where(i => i.ScheduleId == viewModel.Schedule.Id).ToList();


            // Updates the isDone Entries in db
            for (var i = 0; i < dataEntries.Count; i++)
            {
                dataEntries[i].IsDone = viewModel.Tasks[i].IsChecked;
            }

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}