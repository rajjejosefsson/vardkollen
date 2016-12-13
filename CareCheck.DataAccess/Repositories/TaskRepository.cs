using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        public ICollection<Task> TaskList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Tasks.AsNoTracking().ToList();
            }
        }

        public Task FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Tasks.AsNoTracking().SingleOrDefault(t => t.Id == id);
            }
        }

        public void InsertOrUpdate(Task task)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                if (!context.Tasks.Any(t => t.Name == task.Name))
                {
                    context.Tasks.Add(task);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {
                var taskInDb = context.Tasks.SingleOrDefault(e => e.Id == id);
                context.Tasks.Remove(taskInDb);
                context.SaveChanges();
            }
        }
    }
}