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
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {
                return context.Tasks.ToList();
            }
        }

        public Task FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {
                return context.Tasks.SingleOrDefault(t => t.Id == id);
            }
        }

        public void InsertOrUpdate(Task task)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
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
                var taskInDb = context.Tasks.Single(e => e.Id == id);
                context.Tasks.Remove(taskInDb);
                context.SaveChanges();
            }
        }
    }
}