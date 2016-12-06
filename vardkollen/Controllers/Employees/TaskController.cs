﻿using CareCheck.DataAccess;
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

            var schedulesAndPatient = _context.Schedules.Where(s => s.EmployeeId == 1).Include(p => p.Patient).ToList();

            var viewModel = new TasksViewModel
            {
                Schedules = schedulesAndPatient
            };

            return View(viewModel);
        }




        public ActionResult MyAction(int? id)
        {

            var schedule = _context.Schedules.Where(s => s.Id == id)
                                             .Include(t => t.TodoList.Select(i => i.Task))
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
                Tasks = taskItems
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