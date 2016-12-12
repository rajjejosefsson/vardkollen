using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {

        public ICollection<Schedule> ScheduleList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.ToList();
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


        public void DeleteById(int sheduleId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {

                // Check if schedule exists
                var schedule = context.Schedules.Single(s => s.Id == sheduleId);

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



        public ICollection<Schedule> PatientsSchedules()
        {

            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Schedules.Include(p => p.Patient).Include(t => t.TodoList.Select(task => task.Task)).ToList();
            }
        }



        public void Save()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                context.SaveChanges();
            }
        }

    }




}
