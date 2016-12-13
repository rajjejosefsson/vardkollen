using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {



        public ICollection<Schedule> PatientsSchedules()
        {

            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();
            }
        }


        public Schedule FindById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.SingleOrDefault(p => p.Id == scheduleId);
            }
        }

        public Schedule InsertOrUpdate(Schedule schedule)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();

                return schedule; // need to return  schedule and id for adding todolist items after
            }
        }


        public void DeleteById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {

                // Check if schedule exists
                var schedule = context.Schedules.Single(s => s.Id == scheduleId);

                // Get todolist items from the selected schedule
                var todoList = context.TodoList.Where(t => t.ScheduleId == schedule.Id).ToList();

                // remove each item in the list
                foreach (var item in todoList)
                {
                    context.TodoList.Remove(item);
                }

                // remove the schedule from db
                context.Schedules.Remove(schedule);

                context.SaveChanges();
            }
        }







        public Schedule PatientScheduleById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.Where(s => s.Id == scheduleId)
                                               .Include(t => t.TodoList.Select(i => i.Task))
                                               .Include(p => p.Patient.Medications)
                                               .Single();
            }
        }





        public List<Schedule> EmployeeSchedules(int employeeId)
        {

            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                // Employee is hardcoded with id 1 = Martin in Db
                return context.Schedules.Where(e => e.EmployeeId == employeeId)
                                                            .OrderByDescending(s => s.DateTime)
                                                            .Include(p => p.Patient)
                                                            .Include(e => e.Employee)
                                                            .ToList();
            }

        }

















        // for realatives view
        public ICollection<Schedule> PatientDetailSchedules(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.Where(p => p.PatientId == id)
                                 .Include(d => d.TodoList.Select(t => t.Task))
                                 .OrderByDescending(s => s.DateTime)
                                 .ToList();

            }
        }



    }




}
