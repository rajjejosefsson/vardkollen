using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface IMedicaionRepository
    {
        ICollection<Medication> MedicationList();
        void InsertOrUpdate(Medication medication);
        void DeleteById(int id);

    }
}
