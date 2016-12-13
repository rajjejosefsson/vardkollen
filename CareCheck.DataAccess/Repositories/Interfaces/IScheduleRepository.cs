

using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        ICollection<Schedule> PatientsSchedules();
        Schedule FindById(int id);
        Schedule InsertOrUpdate(Schedule schedule);
        void DeleteById(int id);
    }
}
