using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<Task> TaskList();
        Task FindById(int id);
        void InsertOrUpdate(Task task);
        void DeleteById(int id);
    }
}
