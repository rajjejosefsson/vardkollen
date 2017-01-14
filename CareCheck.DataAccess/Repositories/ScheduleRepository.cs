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

            // could be more optimized
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.AsNoTracking().Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();

            }
        }


        public Schedule FindById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.AsNoTracking().SingleOrDefault(p => p.Id == scheduleId);
            }
        }


        public Schedule InsertOrUpdate(Schedule schedule)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();
                return schedule; // need to return schedule object and the id for adding todolist items after
            }
        }


        public void DeleteById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {

                // Get the schedule
                var schedule = context.Schedules.SingleOrDefault(s => s.Id == scheduleId);

                // Get the todolist of the schedule
                var todoList = context.TodoList.Where(t => t.ScheduleId == schedule.Id).ToList();

                // remove each item in the todolist
                foreach (var task in todoList)
                {
                    context.TodoList.Remove(task);

                }

                context.Schedules.Remove(schedule);

                context.SaveChanges();
            }
        }


        public Schedule PatientScheduleById(int scheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.AsNoTracking().Where(s => s.Id == scheduleId)
                                               .Include(t => t.TodoList.Select(i => i.Task))
                                               .Include(p => p.Patient.Medications)
                                               .SingleOrDefault();
            }
        }


        public List<Schedule> EmployeeSchedulesById(int employeeId)
        {

            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                // Employee is hardcoded with id 1 = Martin in Db
                return context.Schedules.AsNoTracking().Where(e => e.EmployeeId == employeeId)
                                                            .OrderByDescending(s => s.DateTime)
                                                            .Include(p => p.Patient)
                                                            .Include(e => e.Employee)
                                                            .ToList();
            }

        }



        // for realatives view
        public ICollection<Schedule> PatientDetailSchedulesById(int patientId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.Where(p => p.PatientId == patientId)
                                 .Include(d => d.TodoList.Select(t => t.Task))
                                 .OrderByDescending(s => s.DateTime)
                                 .ToList();

            }
        }



    }




}
